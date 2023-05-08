<template>
  <div>
    <div class="row">
      <div class="col-sm-8 col-6">
        <h4 class="page-title">
          Danh sách nghỉ phép
        </h4>
      </div>
      <div class="col-sm-4 col-6 text-right m-b-30">
        <router-link
          to="/leave/create"
          class="btn btn-primary btn-rounded float-right"
        >
          <i class="fa fa-plus" /> Thêm mới nghỉ phép
        </router-link>
      </div>
    </div>
    <div class="row filter-row">
      <div class="col-sm-6 col-md-3">
        <div class="form-group form-focus">
          <label class="focus-label">Từ khóa tìm kiếm</label>
          <input
            v-model="searchForm.keyword"
            type="text"
            class="form-control floating"
          >
        </div>
      </div>
      <!-- <div class="col-sm-6 col-md-3">
        <div class="form-group form-focus">
          <label class="focus-label">From</label>
          <div class="cal-icon">
            <input
              class="form-control floating datetimepicker"
              type="text"
            >
          </div>
        </div>
      </div>
      <div class="col-sm-6 col-md-3">
        <div class="form-group form-focus">
          <label class="focus-label">To</label>
          <div class="cal-icon">
            <input
              class="form-control floating datetimepicker"
              type="text"
            >
          </div>
        </div>
      </div> -->
      <div class="col-sm-6 col-md-3">
        <b-button
          class="btn btn-success btn-block"
          @click.prevent="doSearch"
        >
          Tìm kiếm
        </b-button>
        <!-- <a
          href="#"
          class="btn btn-success btn-block"
        > Tìm kiếm</a> -->
      </div>
    </div>
    <TableComponentVue
      ref="tableNhanVien"
      :fields="fields"
      :search-form="searchForm"
      data-url="leave"
      :trang-thais="trangThais"
    />
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
      fields: [
        { key: 'index', label: 'STT' },
        { key: 'userFullName', label: 'Tên nhân viên' },
        { key: 'approveUserFullName', label: 'Người phê duyệt' },
        { key: 'reason', label: 'Lý do' },
        { 
          key: 'createdDate', 
          label: 'Thời gian tạo',
          formatter: (value, key, item) => {
            return formatDate(value, 'DD/MM/yyyy');
          }
        },
        { 
          key: 'createdForDay', 
          label: 'Tạo cho ngày',
          formatter: (value, key, item) => {
            return formatDate(value, 'DD/MM/yyyy');
          }
        },
        { key: 'leaveTypeName', label: 'Loại nghỉ' },
        { key: 'leaveFormName', label: 'Hình thức nghỉ' },
        { key: 'leaveStatusName', label: 'Trạng thái' },
        { key: 'action', label: 'Hành động' },
      ],
      trangThais: [
        { value: 1, text: 'Chờ duyệt' },
        { value: 2, text: 'Đã duyệt' },
        { value: 3, text: 'Từ chối' },
      ],
      searchForm: {
        keyword: '',
      },
    };  
  },
  created(){
    // this.doSearch();
  },
  methods:{
    doSearch(){
      this.$refs.tableNhanVien.doSearch();
    }
  }
}
</script>
