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
        <div class="form-group form-focus">
          <label class="focus-label">Từ khóa tìm kiếm</label>
          <input
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
        <a
          href="#"
          class="btn btn-success btn-block"
        > Tìm kiếm</a>
      </div>
    </div>
    <TableComponentVue :options="items" />
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
        { key: 'heSoLuong', label: 'Hệ số lương' },
        { key: 'soNgayNghiHuongLuong', label: 'Số ngày nghỉ hưởng lương' },
        { key: 'soNgayNghiKhongHuongLuong', label: 'Số ngày nghỉ không hưởng lương' },
        { key: 'tienLuong', label: 'Tổng lương' },
      ],
      items: [
          { index: 1, fullName: 'Lof van ten', heSoLuong: 'Male', soNgayNghiHuongLuong: 42, soNgayNghiKhongHuongLuong: 12, tienLuong: 1000 },
          { index: 2, fullName: 'Lof van ten', heSoLuong: 'Male', soNgayNghiHuongLuong: 42, soNgayNghiKhongHuongLuong: 12, tienLuong: 1000 },
          { index: 3, fullName: 'Lof van ten', heSoLuong: 'Male', soNgayNghiHuongLuong: 42, soNgayNghiKhongHuongLuong: 12, tienLuong: 1000 },
          { index: 4, fullName: 'Lof van ten', heSoLuong: 'Male', soNgayNghiHuongLuong: 42, soNgayNghiKhongHuongLuong: 12, tienLuong: 1000 },
          { index: 5, fullName: 'Lof van ten', heSoLuong: 'Male', soNgayNghiHuongLuong: 42, soNgayNghiKhongHuongLuong: 12, tienLuong: 1000 },

        ]
    };
  }
}
</script>
