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
          to="/nghiphep/create"
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
          @click.stop="doSearch"
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
      data-url="nghiphep"
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
        { key: 'tenNhanVien', label: 'Tên nhân viên' },
        { key: 'nguoiPheDuyet', label: 'Người phê duyệt' },
        { key: 'lyDo', label: 'Lý do' },
        { key: 'thoiGianTao', label: 'Thời gian tạo' },
        { key: 'taoChoNgay', label: 'Tạo cho ngày' },
        { key: 'tenLoaiNghi', label: 'Loại nghỉ' },
        { key: 'tenHinhThucNghi', label: 'Hình thức nghỉ' },
        { key: 'tenTrangThai', label: 'Trạng thái' },
        { key: 'action', label: 'Hành động' },
      ],
      trangThais: [
        { value: 1, text: 'Chờ duyệt' },
        { value: 2, text: 'Đã duyệt' },
        { value: 3, text: 'Từ chối' },
      ],
      searchForm: {
        keyword: null,
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
