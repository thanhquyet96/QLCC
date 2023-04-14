<template>
  <div class="row">
    <div class="col-md-12">
      <div class="card-box">
        <h4 class="card-title">
          Thông tin nhân viên
        </h4>
        <form action="#">
          <div class="form-group">
            <label :required="isEdit">Họ và tên</label>
            <b-form-input
              v-model="$v.nhanVien.hoVaTen.$model"
              :state="isEdit && ($v.nhanVien.hoVaTen.$dirty ? !$v.nhanVien.hoVaTen.$error : null)"
              :disabled="!isEdit"
            />
            <b-form-invalid-feedback>
              Trường này không được để trống
            </b-form-invalid-feedback>
          </div>
          
          <div class="form-group">
            <label>Số điện thoại</label>
            <b-form-input
              v-model="$v.nhanVien.soDienThoai.$model"
              :state="isEdit && ($v.nhanVien.soDienThoai.$dirty ? !$v.nhanVien.soDienThoai.$error : null)"
              :disabled="!isEdit"
            />
            <b-form-invalid-feedback>
              Trường này không được để trống
            </b-form-invalid-feedback>
          </div>
          <div class="form-group">
            <label>Địa chỉ</label>
            <b-form-input
              v-model="$v.nhanVien.diaChi.$model"
              :state="isEdit && ($v.nhanVien.diaChi.$dirty ? !$v.nhanVien.diaChi.$error : null)"
              :disabled="!isEdit"
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
              :disabled="!isEdit"
            >
          </div>
          <div class="form-group">
            <label>Hệ số lương</label>
            <b-form-input
              v-model="$v.nhanVien.heSoLuong.$model"
              :state="isEdit && ($v.nhanVien.heSoLuong.$dirty ? !$v.nhanVien.heSoLuong.$error : null)"
              :disabled="!isEdit"
            />
            <b-form-invalid-feedback>
              Trường này không được để trống
            </b-form-invalid-feedback>
          </div>
          <div class="form-group">
            <label>Số ngày đã nghỉ</label>
            <input
              v-model="nhanVien.soNgayDaNghi"
              type="text"
              class="form-control"
              :disabled="!isEdit"
            >
          </div>
          <div class="form-group">
            <label>Số ngày nghỉ phép</label>
            <input
              v-model="nhanVien.ngayNghiPhep"
              type="text"
              class="form-control"
              :disabled="!isEdit"
            >
          </div>
          <div
            v-if="isEdit"
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
          <div
            v-else
            class="text-right"
          >
            <router-link 
              :to="`/nhanvien/edit/${nhanVien.id}`"
              class="btn btn-primary btn-sm"
            >
              Sửa
            </router-link>
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
        id: null,
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
    id() {
      return this.$route.params.id;
    },
    isEdit() {
      return this.$route.meta.isEdit;
    }
  },
  created() {
    this.getData();
  },
  methods: {
    async getData() {
      const res = await this.$http.get(`nhanvien/${this.id}`);
      this.nhanVien = res?.data || {};
      this.nhanVien.sinhNhat = res?.data.sinhNhat?.split('T')[0];

    },
    async save() {
      this.$v.$touch()
      if (!this.$v.$invalid){
        await this.$http.put(`nhanvien/${this.id}`, this.nhanVien);
        this.$toast.success('Cập nhật thành công!');
        this.cancel();
      }
      
    },
    cancel() {
      this.$router.push(`/nhanvien/detail/${this.id}`);
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