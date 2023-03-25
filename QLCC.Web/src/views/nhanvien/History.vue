<!-- eslint-disable vue/valid-v-slot -->
<!-- eslint-disable vue/no-v-for-template-key-on-child -->
<!-- eslint-disable vue/valid-v-for -->
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
            v-model="searchForm.keyWord"
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
        > Tìm kiếm </a>
      </div>
    </div>
    <div class="row">
      <div class="col-lg-12">
        <div class="table-responsive">
          <!-- <table class="table table-striped custom-table mb-0">
            <thead>
              <tr>
                <th>Nhân viên</th>
                <th>1</th>
                <th>2</th>
                <th>3</th>
                <th>4</th>
                <th>5</th>
                <th>6</th>
                <th>7</th>
                <th>8</th>
                <th>9</th>
                <th>10</th>
                <th>11</th>
                <th>12</th>
                <th>13</th>
                <th>14</th>
                <th>15</th>
                <th>16</th>
                <th>17</th>
                <th>18</th>
                <th>19</th>
                <th>20</th>
                <th>22</th>
                <th>23</th>
                <th>24</th>
                <th>25</th>
                <th>26</th>
                <th>27</th>
                <th>28</th>
                <th>29</th>
                <th>30</th>
                <th>31</th>
              </tr>
            </thead>
            <tbody>
              <tr>
                <td>Albina Simonis</td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td>
                  <div class="half-day">
                    <span class="first-off"><i class="fa fa-check text-success" /></span> <span class="first-off"><i class="fa fa-close text-danger" /></span>
                  </div>
                </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-close text-danger" /> </td>
                <td><i class="fa fa-close text-danger" /> </td>
                <td><i class="fa fa-close text-danger" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-close text-danger" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td>
                  <div class="half-day">
                    <span class="first-off"><i class="fa fa-close text-danger" /></span> <span class="first-off"><i class="fa fa-check text-success" /></span>
                  </div>
                </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-close text-danger" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-close text-danger" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
              </tr>
              <tr>
                <td>Cristina Groves</td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-close text-danger" /> </td>
                <td><i class="fa fa-close text-danger" /> </td>
                <td><i class="fa fa-close text-danger" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-close text-danger" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-close text-danger" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-close text-danger" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
              </tr>
              <tr>
                <td>Haylie Feeney</td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-close text-danger" /> </td>
                <td><i class="fa fa-close text-danger" /> </td>
                <td><i class="fa fa-close text-danger" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-close text-danger" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-close text-danger" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-close text-danger" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
              </tr>
              <tr>
                <td>Mary Mericle</td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-close text-danger" /> </td>
                <td><i class="fa fa-close text-danger" /> </td>
                <td><i class="fa fa-close text-danger" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-close text-danger" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-close text-danger" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-close text-danger" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
              </tr>
              <tr>
                <td>Zoe Butler</td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-close text-danger" /> </td>
                <td><i class="fa fa-close text-danger" /> </td>
                <td><i class="fa fa-close text-danger" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-close text-danger" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-close text-danger" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-close text-danger" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
              </tr>
              <tr>
                <td>Cristina Groves</td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-close text-danger" /> </td>
                <td><i class="fa fa-close text-danger" /> </td>
                <td><i class="fa fa-close text-danger" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-close text-danger" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-close text-danger" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-close text-danger" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
              </tr>
              <tr>
                <td>Marie Wells</td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-close text-danger" /> </td>
                <td><i class="fa fa-close text-danger" /> </td>
                <td><i class="fa fa-close text-danger" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-close text-danger" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-close text-danger" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-close text-danger" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
              </tr>
              <tr>
                <td>Henry Daniels</td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-close text-danger" /> </td>
                <td><i class="fa fa-close text-danger" /> </td>
                <td><i class="fa fa-close text-danger" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-close text-danger" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-close text-danger" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-close text-danger" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
              </tr>
              <tr>
                <td>Mark Hunter</td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-close text-danger" /> </td>
                <td><i class="fa fa-close text-danger" /> </td>
                <td><i class="fa fa-close text-danger" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-close text-danger" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-close text-danger" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-close text-danger" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
              </tr>
              <tr>
                <td>Michael Sullivan</td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-close text-danger" /> </td>
                <td><i class="fa fa-close text-danger" /> </td>
                <td><i class="fa fa-close text-danger" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-close text-danger" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-close text-danger" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-close text-danger" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
                <td><i class="fa fa-check text-success" /> </td>
              </tr>
            </tbody>
          </table> -->
          <TableComponentVue 
            :fields="fields"
            :items="items"
            data-url="nhanvien/history"
          />
          <!-- <b-table
            sticky-header
            responsive
            striped
            hover
            :fields="fields"
            :items="items"
            :busy="isBusy"
            show-empty
          >
            
          </b-table> -->
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
          keyWord: null,
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
      },
      'searchForm.year'(val) {
        this.loadFields();
      },
    },
    created() {
      this.loadFields();
    },
    mounted() {
      // Datetimepicker
      if($('.datetimepicker').length > 0) {
        $('.datetimepicker').datetimepicker({
          format: 'DD/MM/YYYY'
        });
      }
      $("[class=raw-icon]").each((index, item) => {
        debugger;
          const value = $(item).text();
          console.log('value',value);
          $(item).html(value);
      });
    },
    methods: {
      loadFields() {
        const days = getAllDaysInMonth(this.searchForm.month, this.searchForm.year);
        const keys = Object.keys(days).map(x=> { return Number(x) + 1 });
        this.fields = [...this.fieldDefault, ...keys.map(x=> { 
          return { 
            key: `${x}`, 
            label: x.toString(),
            class: 'raw-icon',
            name: 'quyetdaika',
            formatter: (value) => {
              const a = '<i class="fa fa-check text-success" />';
              console.log(this);
              return this.checkIcon(value);
            }
           }
          })
        ];
      },
      loadHistories() {

      },
      checkIcon(type){
        switch(type){
          // Đi làm
          case 1: 
            return `<i class="fa fa-check text-success" />`;
          // Nghỉ cả ngày
          case 2: 
           return '<i class="fa fa-close text-danger" />';
          // Nghỉ buổi sáng
          case 3: 
            return '<div class="half-day"><span class="first-off"><i class="fa fa-close text-danger" /></span> <span  class="first-off"><i class="fa fa-check text-success" /></span></div>';
          // Nghỉ buổi chiều
          case 4: 
          return '<div class="half-day"><span class="first-off"><i class="fa fa-close text-success" /></span> <span  class="first-off"><i class="fa fa-check text-danger" /></span></div>';
        }
      },
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