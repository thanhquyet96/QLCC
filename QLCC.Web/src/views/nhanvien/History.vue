<template>
  <div>
    <div class="row">
      <div class="col-sm-12">
        <h4 class="page-title">
          Lịch sử chấm công tháng {{ searchForm.month }} - {{ searchForm.year }}
        </h4>
      </div>
    </div>
    <div class="row filter-row">
      <div class="col-sm-6 col-md-3">
        <b-form-group
          label="Từ khóa:"
        >
          <b-form-input
            v-model="searchForm.keyword"
            type="text"
            placeholder="Nhập từ khóa"
            required
          />
        </b-form-group>
      </div>
      <div class="col-sm-6 col-md-3">
        <b-form-group
          label="Tháng:"
        >
          <b-form-select
            v-model="searchForm.month"
            :options="months"
            class="mb-3"
            value-field="item"
            text-field="name"
            disabled-field="notEnabled"
          />
        </b-form-group>
      </div>
      <div class="col-sm-6 col-md-3">
        <b-form-group
          label="Năm:"
        >
          <b-form-select
            v-model="searchForm.year"
            :options="years"
            class="mb-3"
            value-field="item"
            text-field="name"
            disabled-field="notEnabled"
          />
        </b-form-group>
      </div>
      <div class="col-sm-6 col-md-3">
        <a
          href="#"
          class="btn btn-success btn-block"
          style="margin-top: 15px;"
          @click="doSearch"
        > Tìm kiếm </a>
      </div>
    </div>
    <div class="row">
      <div class="col-lg-12">
        <div class="table-responsive">
          <TableComponentVue 
            :fields="fields"
            :options="items"
          />
        </div>
      </div>
    </div>
  </div>
</template>

  <script>
    import TableComponentVue from "@/components/TableComponent.vue"

    export default {
    name: 'ListView',
    components: {
      TableComponentVue
    },
    data() {
      return {
        labelIcon: '<i class="fa fa-check text-success" />',
        formatted: [1,2,3,4,5,6],
        items: [
          { hoVaTen: 'Lof van ten', 1: 1, 2: 2, 3: 3, 5: 5, loaiNghi: 1 },
        ],
        fieldDefault: [
          // { key: 'index', label: 'STT' },
          { key: 'hoVaTen', label: 'Nhân viên' },
        ],
        fields: [],
        searchForm: {
          keyword: '',
          month: new Date().getMonth() + 1,
          year: new Date().getFullYear(),
        },
        months:[
          { item: 1, name: 1 },
          { item: 2, name: 2 },
          { item: 3, name: 3 },
          { item: 4, name: 4 },
          { item: 5, name: 5 },
          { item: 6, name: 6 },
          { item: 7, name: 7 },
          { item: 8, name: 8 },
          { item: 9, name: 9 },
          { item: 10, name: 10 },
          { item: 11, name: 11 },
          { item: 12, name: 12},
        ],
        years: [
        { item: 2019, name: 2019},
        { item: 2020, name: 2020},
        { item: 2021, name: 2021},
        { item: 2022, name: 2022},
        { item: 2023, name: 2023},

        ],
        isBusy: true,
       
      };
    },
    watch: {
      'searchForm.month'(val) {
        this.loadFields();
        this.loadHistories();
      },
      'searchForm.year'(val) {
        this.loadFields();
        this.loadHistories();
      },
    },
    created() {
      this.loadFields();
      this.loadHistories();
    },
    mounted() {
      // Datetimepicker
      if($('.datetimepicker').length > 0) {
        $('.datetimepicker').datetimepicker({
          format: 'DD/MM/YYYY'
        });
      }
      
    },
    methods: {
      loadFields() {
        const days = getAllDaysInMonth(this.searchForm.month, this.searchForm.year);
        const keys = Object.keys(days).map(x=> { return Number(x) + 1 });
        this.fields = [...this.fieldDefault, ...keys.map(x=> { 
          return { 
            key: `heading_${x}`, 
            label: x.toString(),
            class: 'raw-icon',
            // name: 'quyetdaika',
            // formatter: (value) => {
            //   const a = '<i class="fa fa-check text-success" />';
            //   console.log(this);
            //   return this.checkIcon(value);
            // }
           }
          })
        ];
      },
      async loadHistories() {
        const query = new URLSearchParams(this.searchForm).toString()
        this.items = [];
        const {data} = await this.$http.get(`lichsuchamcong?${query}`);
        this.items = data || [];
        this.$nextTick(() => {
          this.rawIcon();
        });
      },
      doSearch() {
        this.loadHistories();
      },
      checkIcon(type){
        switch(type){
          // Đi làm
          case 1: 
            return `<i class="fa fa-check text-success"></i>`;
          // Nghỉ cả ngày
          case 2: 
           return '<i class="fa fa-close text-danger"></i>';
          // Nghỉ buổi sáng
          case 3: 
            return '<div class="half-day"><span class="first-off"><i class="fa fa-close text-danger"></i></span><span class="first-off"><i class="fa fa-check text-success"></i></span></div>';
          // Nghỉ buổi chiều
          case 4: 
            return '<div class="half-day"><span class="first-off"><i class="fa fa-close text-success"></i></span><span class="first-off"><i class="fa fa-check text-danger"></i></span></div>';
          case 5: 
            return '<b style="font-weight: 900;" title="Không xác định">~</b>';
          default: 
            return '<i class="fa fa-close text-danger"></i>';
        }
      },
      rawIcon() {
        const vm = this;
        $("tbody [class=raw-icon]").each((index, item) => {
          const value = $(item).data('value') || item.innerText;
          $(item).data('value', value);
          item.innerText = '';
          const html = this.checkIcon(Number(value));
          if(item.innerHtml !== html) {
            $(item).append(html);
          }
        });
      }
    },
  }

    const getAllDaysInMonth = (month, year) =>
      Array.from(
        { length: new Date(year, month, 0).getDate() },
        (_, i) => new Date(year, month - 1, i + 1)
      );
  </script>
  <style scoped>
    .form-group {
        text-align: left;
    }
    select{
      width: 100%;
    }
  </style>