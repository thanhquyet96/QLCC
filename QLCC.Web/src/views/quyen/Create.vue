<template>
  <div class="row">
    <div class="col-md-12">
      <div class="card-box">
        <h4 class="card-title">
          Thêm mới quyền
        </h4>
        <form action="#">
          <div class="form-group">
            <label>Tên quyền</label>
            <b-form-input
              v-model="$v.quyen.name.$model"
              :state="$v.quyen.name.$dirty ? !$v.quyen.name.$error : null"
            />
            <b-form-invalid-feedback>
              Trường này không được để trống
            </b-form-invalid-feedback>
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
      quyen: {
        name: null,
      }
    };
  },
  validations: {
    quyen: {
      name: {
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
        await this.$http.post(`role`, this.quyen);
        this.$toast.success('Thêm mới thành công!');
        this.cancel();
      }
      
    },
    cancel() {
      this.$router.push(`/quyen`);
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