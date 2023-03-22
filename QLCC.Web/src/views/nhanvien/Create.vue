<template>
  <div class="row">
    <div class="col-md-12">
      <div class="card-box">
        <h4 class="card-title">
          Thêm mới nhân viên
        </h4>
        <form action="#">
          <div class="form-group">
            <label>Họ và tên</label>
            <b-form-input
              v-model="$v.nhanVien.hoVaTen.$model"
              :state="($v.nhanVien.hoVaTen.$model !== null) && !$v.nhanVien.hoVaTen.$error"
            />
            <b-form-invalid-feedback>
              Trường này không được để trống
            </b-form-invalid-feedback>
          </div>
          
          <div class="form-group">
            <label>Số điện thoại</label>
            <b-form-input
              v-model="$v.nhanVien.soDienThoai.$model"
              :state="($v.nhanVien.soDienThoai.$model !== null) && !$v.nhanVien.soDienThoai.$error"
            />
            <b-form-invalid-feedback>
              Trường này không được để trống
            </b-form-invalid-feedback>
          </div>
          <div class="form-group">
            <label>Địa chỉ</label>

            <b-form-input
              v-model="$v.nhanVien.diaChi.$model"
              :state="($v.nhanVien.diaChi.$model !== null) && !$v.nhanVien.diaChi.$error"
            />
            <b-form-invalid-feedback>
              Trường này không được để trống
            </b-form-invalid-feedback>
          </div>
          <div class="form-group">
            <label>Sinh nhật</label>
            <input
              v-model="nhanVien.sinhNhat"
              type="date"
              class="form-control"
            >
          </div>
          <div class="form-group">
            <label>Hệ số lương</label>
            <b-form-input
              v-model="$v.nhanVien.heSoLuong.$model"
              type="number"
              :state="($v.nhanVien.heSoLuong.$model !== null) && !$v.nhanVien.heSoLuong.$error"
            />
            <b-form-invalid-feedback>
              Trường này không được để trống
            </b-form-invalid-feedback>
          </div>
          <div class="form-group">
            <label>Số ngày đã nghỉ</label>
            <input
              v-model="nhanVien.soNgayDaNghi"
              type="number"
              class="form-control"
            >
          </div>
          <div class="form-group">
            <label>Số ngày nghỉ phép</label>
            <input
              v-model="nhanVien.ngayNghiPhep"
              type="number"
              class="form-control"
            >
          </div>
          <div
            class="text-right"
          >
            <b-button
              variant="success"
              @click="save"
            >
              Lưu
            </b-button>
            <b-button
              variant="danger"
              @click="cancel"
            >
              Hủy
            </b-button>
          </div>
        </form>
      </div>
    </div>
  </div>
</template>

<script>
import { required, minLength, between } from 'vuelidate/lib/validators'

export default {
  name: 'ListView',
  components: {

  },
  data() {
    return {
      nhanVien: {
        diaChi: null,
        heSoLuong: null,
        hoVaTen: null,
        id: 0,
        ngayNghiPhep: null,
        sinhNhat: null,
        soDienThoai: null,
        soNgayDaNghi: null,
        // taiKhoan: null,
      }
    };
  },
  validations: {
    nhanVien: {
      hoVaTen: {
        required,
      },
      diaChi: {
        required,
      },
      soDienThoai: {
        required,
      },
      heSoLuong: {
        required,
      },
    }
  },
  computed: {
   
  },
  created() {
  },
  methods: {
    async save() {
      this.$v.$touch()
      if (!this.$v.$invalid){
        await this.$http.post(`nhanvien`, this.nhanVien);
        this.$toast.success('Thêm mới thành công!');
        this.cancel();
      }
      
    },
    cancel() {
      this.$router.push(`/nhanvien`);
    }
  },
}
</script>
<style scoped>
.form-group {
  text-align: left;
}

input {}
</style>