<template>
  <div class="row">
    <div class="col-md-12">
      <div class="card-box">
        <h4 class="card-title">
          Thêm mới tài khoản
        </h4>
        <form action="#">
          <div class="form-group">
            <label>Họ và tên</label>
            <b-form-input
              v-model="$v.nhanVien.fullName.$model"
              :state="$v.nhanVien.fullName.$dirty ? !$v.nhanVien.fullName.$error : null"
            />
            <b-form-invalid-feedback>
              Trường này không được để trống
            </b-form-invalid-feedback>
          </div>
          <div class="form-group">
            <label>Tài khoản</label>
            <b-form-input
              v-model="$v.nhanVien.userName.$model"
              :state="$v.nhanVien.userName.$dirty ? !$v.nhanVien.userName.$error : null"
            />
            <b-form-invalid-feedback>
              Trường này không được để trống
            </b-form-invalid-feedback>
          </div>
          <div class="form-group">
            <label>Mật khẩu</label>
            <b-form-input
              v-model="$v.nhanVien.password.$model"
              type="password"
              :state="$v.nhanVien.password.$dirty ? !$v.nhanVien.password.$error : null"
            />
            <b-form-invalid-feedback>
              Trường này không được để trống
            </b-form-invalid-feedback>
          </div>
          <div class="form-group">
            <label>Số điện thoại</label>
            <b-form-input
              v-model="$v.nhanVien.phoneNumber.$model"
              :state="$v.nhanVien.phoneNumber.$dirty ? !$v.nhanVien.phoneNumber.$error : null"
            />
            <b-form-invalid-feedback>
              Trường này không được để trống
            </b-form-invalid-feedback>
          </div>
          <div class="form-group">
            <label>Địa chỉ</label>

            <b-form-input
              v-model="$v.nhanVien.address.$model"
              :state="$v.nhanVien.address.$dirty ? !$v.nhanVien.address.$error : null"
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
            >
          </div>
          <div class="form-group">
            <label>Hệ số lương</label>
            <b-form-input
              v-model="$v.nhanVien.coefficientsSalary.$model"
              type="number"
              :state="$v.nhanVien.coefficientsSalary.$dirty ? !$v.nhanVien.coefficientsSalary.$error : null"
            />
            <b-form-invalid-feedback>
              Trường này không được để trống
            </b-form-invalid-feedback>
          </div>
          <div class="form-group">
            <label>Số ngày đã nghỉ</label>
            <input
              v-model="nhanVien.numberOfDays"
              type="number"
              class="form-control"
            >
          </div>
          <div class="form-group">
            <label>Số ngày nghỉ phép</label>
            <input
              v-model="nhanVien.vacationDay"
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
        address: null,
        coefficientsSalary: null,
        fullName: null,
        id: 0,
        vacationDay: null,
        birthDay: null,
        phoneNumber: null,
        numberOfDays: null,
        userName: null,
        password: null,
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
      userName: {
        required,
      },
      password: {
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
        await this.$http.post(`user`, this.nhanVien);
        this.$toast.success('Thêm mới thành công!');
        this.cancel();
      }
      
    },
    cancel() {
      this.$router.push(`/taikhoan`);
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