<template>
  <div>
    <div class="row">
      <div class="col-sm-8 col-6">
        <h4 class="page-title">
          Danh sách tài khoản
        </h4>
      </div>
      <div class="col-sm-4 col-6 text-right m-b-30">
        <router-link
          to="/taikhoan/create"
          class="btn btn-primary btn-rounded float-right"
        >
          <i class="fa fa-plus" /> Thêm mới tài khoản
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
      ref="tableTaiKhoan"
      :fields="fields"
      :search-form="searchForm"
      data-url="taikhoan"
    >
      <template #btn-more="{ data }">
        <!-- <b-button
          class="m-l-1"
          variant="outline-primary"
          size="sm"
        >
          Phân quyền {{ data }}
        </b-button> -->
        <router-link
          :to="`/taikhoan/privilege/${data.item.id}`"
          class="btn btn-outline-primary btn-sm m-l-1"
        >
          Phân quyền
        </router-link>
      </template>
      <!-- <template 
        #btn-more
      >
        <b-button
          class="m-l-1"
          variant="outline-primary"
          size="sm"
          v-slot="{ row }"
        >
          Phân quyền {{ row }}
        </b-button>
        <router-link
          :to="`/quyen/privilege/`"
          class="btn outline-primary btn-sm m-l-1"
          @click="btnClick"
        >
          Phân quyền
        </router-link>
      </template> -->
    </TableComponentVue>
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
        { key: 'hoVaTen', label: 'Họ và tên' },
        { key: 'taiKhoan', label: 'Tài khoản' },
        { key: 'diaChi', label: 'Địa chỉ' },
        {
           key: 'sinhNhat', 
           label: 'Sinh nhật',
           formatter: (value, key, item) => {
              return formatDate(value, 'DD/MM/yyyy');
           }
        },
        { key: 'soDienThoai', label: 'Số điện thoại' },
        { key: 'soNgayDaNghi', label: 'Số ngày đã nghỉ' },
        { key: 'ngayNghiPhep', label: 'Số ngày nghỉ phép' },
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
      this.$refs.tableTaiKhoan.doSearch();
    }
  }
}
</script>
