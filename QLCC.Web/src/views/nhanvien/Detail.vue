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
              v-model="$v.nhanVien.fullName.$model"
              :state="isEdit && ($v.nhanVien.fullName.$dirty ? !$v.nhanVien.fullName.$error : null)"
              :disabled="!isEdit"
            />
            <b-form-invalid-feedback>
              Trường này không được để trống
            </b-form-invalid-feedback>
          </div>
          
          <div class="form-group">
            <label>Số điện thoại</label>
            <b-form-input
              v-model="$v.nhanVien.phoneNumber.$model"
              :state="isEdit && ($v.nhanVien.phoneNumber.$dirty ? !$v.nhanVien.phoneNumber.$error : null)"
              :disabled="!isEdit"
            />
            <b-form-invalid-feedback>
              Trường này không được để trống
            </b-form-invalid-feedback>
          </div>
          <div class="form-group">
            <label>Địa chỉ</label>
            <b-form-input
              v-model="$v.nhanVien.address.$model"
              :state="isEdit && ($v.nhanVien.address.$dirty ? !$v.nhanVien.address.$error : null)"
              :disabled="!isEdit"
            />
            <b-form-invalid-feedback>
              Trường này không được để trống
            </b-form-invalid-feedback>
          </div>
          <div class="form-group">
            <label>Sinh nhật</label>
            <input
              v-model="nhanVien.birthDay"
              type="date"
              class="form-control"
              :disabled="!isEdit"
            >
          </div>
          <div class="form-group">
            <label>Hệ số lương</label>
            <b-form-input
              v-model="$v.nhanVien.coefficientsSalary.$model"
              :state="isEdit && ($v.nhanVien.coefficientsSalary.$dirty ? !$v.nhanVien.coefficientsSalary.$error : null)"
              :disabled="!isEdit"
            />
            <b-form-invalid-feedback>
              Trường này không được để trống
            </b-form-invalid-feedback>
          </div>
          <div class="form-group">
            <label>Số ngày đã nghỉ</label>
            <input
              v-model="nhanVien.numberOfDays"
              type="text"
              class="form-control"
              :disabled="!isEdit"
            >
          </div>
          <div class="form-group">
            <label>Số ngày nghỉ phép</label>
            <input
              v-model="nhanVien.vacationDay"
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
        address: null,
        coefficientsSalary: null,
        fullName: null,
        id: null,
        vacationDay: null,
        birthDay: null,
        phoneNumber: null,
        numberOfDays: null,
        // userName: null,
      }
    };
  },
  validations: {
    nhanVien: {
      fullName: {
        required,
      },
      address: {
        required,
      },
      phoneNumber: {
        required,
      },
      coefficientsSalary: {
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
      const res = await this.$http.get(`user/${this.id}`);
      this.nhanVien = res?.data || {};
      this.nhanVien.birthDay = res?.data.birthDay?.split('T')[0];

    },
    async save() {
      this.$v.$touch()
      if (!this.$v.$invalid){
        await this.$http.put(`user/${this.id}`, this.nhanVien);
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