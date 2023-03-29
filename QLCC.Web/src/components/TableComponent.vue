<template>
  <div class="row">
    <div class="col-md-12">
      <b-table
        striped
        hover
        :fields="fields"
        :items="items"
        :busy="isBusy"
        show-empty
      >
        <template #cell(index)="data">
          {{ data.index + 1 }}
        </template>

        <template
          v-if="showTrangThai"
          #cell(tenTrangThai)="row"
        >
          <b-form-select
            v-model="row.item.trangThai"
            :options="trangThais"
            @change="changeStatus(row.item.id, row.item.trangThai)"
          />
        </template>
        
        <template #cell(action)="row">
          <!-- <slot
            :events="{ atClick: fnNext(row) }"
            name="btn-more"
          /> -->
          <slot
            name="btn-more"
            :data="row"
          />
          
          <router-link
            :to="`/${dataUrl}/detail/${row.item.id}`"
            class="btn btn-primary btn-sm m-l-1"
          >
            Xem
          </router-link>
          <router-link 
            v-if="!showTrangThai"
            :to="`/${dataUrl}/edit/${row.item.id}`"
            class="btn btn-success btn-sm m-l-1"
          >
            Sửa
          </router-link>
          <b-button
            v-if="!row.item.trangThai || row.item.trangThai === 1"
            class="m-l-1"
            variant="danger"
            size="sm"
            @click="deleteModel(row.item.id)"
          >
            Xóa
          </b-button>
        </template>
        <template #table-busy>
          <div class="text-center text-danger my-2">
            <b-spinner class="align-middle" />
            <!-- <strong>Loading...</strong> -->
          </div>
        </template>
        <template #empty="scope">
          <h4>{{ scope.emptyText }}</h4>
        </template>
        <template #emptyfiltered="scope">
          <h4>{{ scope.emptyFilteredText }}</h4>
        </template>
      </b-table>
    </div>
  </div>
</template>
<script>
export default {
  name: 'TableView',
  props: {
    options: {
      type: Array,
      default: () => []
    },
    headers: {
      type: Array,
      default: () => []
    },
    dataUrl: {
      type: String,
      default: () => ''
    },
    fields: {
      type: Array,
      default: () => []
    },
    searchForm: {
      type: Object,
      default: () => {}
    },
    trangThais: {
      type: Array,
      default: () => []
    }
  },
  data() {
    return {
      fields2: [
        // A virtual column that doesn't exist in items
        { key: 'index', label: 'STT' },
        // A column that needs custom formatting
        { key: 'name', label: 'Họ và tên' },
        // A regular column
        { key: 'age', label: 'Sinh nhật' },
        // A regular column
        { key: 'a', label: 'Địa chỉ' },
        // A virtual column made up from two fields
        { key: 'nameage', label: 'Số điện thoại' },
        'action'
      ],
      items: [
        { name: { first: 'John', last: 'Doe' }, sex: 'Male', age: 42 },
        { name: { first: 'Jane', last: 'Doe' }, sex: 'Female', age: 36 },
        { name: { first: 'Rubin', last: 'Kincade' }, sex: 'Male', age: 73 },
        { name: { first: 'Shirley', last: 'Partridge' }, sex: 'Female', age: 62 }
      ],
      isBusy: true,
    }
  },
  computed: {
    showTrangThai() {
      return this.fields.find(x=>x.key === 'tenTrangThai');
    }
  },
  watch: {
    options() {
      this.items = this.options;
      this.isBusy = false;
    }
  },
  created() {
    if(this.dataUrl !== '') {
      this.doSearch();
    }
  },
  methods: {
    async doSearch() {
      this.isBusy = true;
      const query = new URLSearchParams(this.searchForm).toString()
      const res = await this.$http.get(`${this.dataUrl}?${query}`);
      this.items = res?.data || [];
      this.isBusy = false;

    },
    async deleteModel(id) {
      this.isBusy = true;

      await this.$http.delete(`${this.dataUrl}/${id}`);
      this.isBusy = false;

      this.$toast.success('Xóa thành công!');
      await this.doSearch();
    },
    async changeStatus(id, value) {
      await this.$http.put(`${this.dataUrl}/${id}/update-status?status=${value}`);
      this.$toast.success('Cập nhật thành công!');
      await this.doSearch();

    },
  }
}
</script>
<style>
  
</style>