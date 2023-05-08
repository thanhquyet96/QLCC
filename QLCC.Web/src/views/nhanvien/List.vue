<template>
  <div>
    <div class="row">
      <div class="col-sm-8 col-6">
        <h4 class="page-title">
          Danh sách nhân viên
        </h4>
      </div>
      <div class="col-sm-4 col-6 text-right m-b-30">
        <router-link
          to="/nhanvien/create"
          class="btn btn-primary btn-rounded float-right"
        >
          <i class="fa fa-plus" /> Thêm mới nhân viên
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
      data-url="user"
      path="nhanvien"
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
        { key: 'fullName', label: 'Họ và tên' },
        { key: 'address', label: 'Địa chỉ' },
        { 
          key: 'birthDay', 
          label: 'Sinh nhật', 
          formatter: (value, key, item) => {
              return formatDate(value, 'DD/MM/yyyy');
          }
        },
        { key: 'phoneNumber', label: 'Số điện thoại' },
        { key: 'numberOfDays', label: 'Số ngày đã nghỉ' },
        { key: 'vacationDay', label: 'Số ngày nghỉ phép' },
        { key: 'action', label: 'Hành động' },
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
    },
  }
}
</script>
