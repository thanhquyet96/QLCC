<template>
  <div>
    <div class="row">
      <div class="col-sm-8 col-6">
        <h4 class="page-title">
          Tính lương tháng 12/2022
        </h4>
      </div>
      <div class="col-sm-4 col-6 text-right m-b-30">
        <!-- <router-link to="/nhanvien/create" class="btn btn-primary btn-rounded float-right"><i class="fa fa-plus" /> Thêm mới nhân viên</router-link> -->
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
          @click.prevent="doSearch"
        > Tìm kiếm </a>
      </div>
    </div>
    <TableComponentVue
      :fields="headers"
      :options="items"
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
      headers: [
        { key: 'index', label: 'STT' },
        { key: 'fullName', label: 'Họ và tên' },
        { key: 'coefficientsSalary', label: 'Hệ số lương' },
        { key: 'onLeave', label: 'Số ngày nghỉ hưởng lương' },
        { key: 'sUnpaidLeave', label: 'Số ngày nghỉ không hưởng lương' },
        { 
          key: 'salary', 
          label: 'Tổng lương',
          formatter: (value) => {
            return new Intl.NumberFormat('vi-VN', { style: 'currency', currency: 'VND' }).format(value);
          }
        },
        { key: 'show_details', label: 'Chi tiết'}
      ],
      items: [
          { index: 1, fullName: 'Lof van ten', coefficientsSalary: 'Male', soNgayNghiHuongLuong: 42, soNgayNghiKhongHuongLuong: 12, tienLuong: 1000 },
          { index: 2, fullName: 'Lof van ten', coefficientsSalary: 'Male', soNgayNghiHuongLuong: 42, soNgayNghiKhongHuongLuong: 12, tienLuong: 1000 },
          { index: 3, fullName: 'Lof van ten', coefficientsSalary: 'Male', soNgayNghiHuongLuong: 42, soNgayNghiKhongHuongLuong: 12, tienLuong: 1000 },
          { index: 4, fullName: 'Lof van ten', coefficientsSalary: 'Male', soNgayNghiHuongLuong: 42, soNgayNghiKhongHuongLuong: 12, tienLuong: 1000 },
          { index: 5, fullName: 'Lof van ten', coefficientsSalary: 'Male', soNgayNghiHuongLuong: 42, soNgayNghiKhongHuongLuong: 12, tienLuong: 1000 },

        ],
        searchForm: {
          keyWord: '',
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
    };
  },
  watch: {
    searchForm: {
      handler() {
        this.doSearch();
      },
      deep: true,
    }
  },
  created() {
    this.funPayroll();
  },
  methods: {
    async doSearch() {
      await this.funPayroll();
    },
    async funPayroll() {
      const query = new URLSearchParams(this.searchForm).toString()

      const {data} = await this.$http.post(`timeKeep/payroll?${query}`);
      this.items = data;
    },
    formatCurrency(value) {
      return new Intl.NumberFormat('vi-VN', { style: 'currency', currency: 'VND' }).format(value);

    }
  }
}
</script>
