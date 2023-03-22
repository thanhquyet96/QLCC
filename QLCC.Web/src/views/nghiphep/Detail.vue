<template>
  <div class="row">
    <div class="col-md-12">
      <div class="card-box">
        <h4 class="card-title">
          Thông tin nghỉ phép
        </h4>
        <form action="#">
          <div class="form-group">
            <label :required="isEdit">Họ và tên</label>
            <b-form-input
              v-model="$v.nghiPhep.hoVaTen.$model"
              :state="isEdit && !$v.nghiPhep.hoVaTen.$error"
              :disabled="!isEdit"
            />
            <b-form-invalid-feedback>
              Trường này không được để trống
            </b-form-invalid-feedback>
          </div>
          
          <div class="form-group">
            <label>Số điện thoại</label>
            <b-form-input
              v-model="$v.nghiPhep.soDienThoai.$model"
              :state="isEdit && !$v.nghiPhep.soDienThoai.$error"
              :disabled="!isEdit"
            />
            <b-form-invalid-feedback>
              Trường này không được để trống
            </b-form-invalid-feedback>
          </div>
          <div class="form-group">
            <b-form-input
              v-model="$v.nghiPhep.diaChi.$model"
              :state="isEdit && !$v.nghiPhep.diaChi.$error"
              :disabled="!isEdit"
            />
            <b-form-invalid-feedback>
              Trường này không được để trống
            </b-form-invalid-feedback>
          </div>
          <div class="form-group">
            <label>Sinh nhật</label>
            <input
              v-model="nghiPhep.sinhNhat"
              type="datetime"
              class="form-control"
              :disabled="!isEdit"
            >
          </div>
          <div class="form-group">
            <label>Hệ số lương</label>
            <b-form-input
              v-model="$v.nghiPhep.heSoLuong.$model"
              :state="isEdit && !$v.nghiPhep.heSoLuong.$error"
              :disabled="!isEdit"
            />
            <b-form-invalid-feedback>
              Trường này không được để trống
            </b-form-invalid-feedback>
          </div>
          <div class="form-group">
            <label>Số ngày đã nghỉ</label>
            <input
              v-model="nghiPhep.soNgayDaNghi"
              type="text"
              class="form-control"
              :disabled="!isEdit"
            >
          </div>
          <div class="form-group">
            <label>Số ngày nghỉ phép</label>
            <input
              v-model="nghiPhep.ngayNghiPhep"
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
              :to="`/nghiphep/edit/${nghiPhep.id}`"
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
      nghiPhep: {
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
    nghiPhep: {
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
      const res = await this.$http.get(`nghiphep/${this.id}`);
      this.nghiPhep = res?.data || {};
    },
    async save() {
      this.$v.$touch()
      if (!this.$v.$invalid){
        await this.$http.put(`nghiphep/${this.id}`, this.nghiPhep);
        this.$toast.success('Cập nhật thành công!');
        this.cancel();
      }
      
    },
    cancel() {
      this.$router.push(`/nghiphep/detail/${this.id}`);
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