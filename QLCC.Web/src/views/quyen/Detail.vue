<template>
  <div class="row">
    <div class="col-md-12">
      <div class="card-box">
        <h4 class="card-title">
          Thông tin quyền
        </h4>
        <form action="#">
          <div class="form-group">
            <label :required="isEdit">Tên quyền</label>
            <b-form-input
              v-model="$v.quyen.tenQuyen.$model"
              :state="isEdit && !$v.quyen.tenQuyen.$error"
              :disabled="!isEdit"
            />
            <b-form-invalid-feedback>
              Trường này không được để trống
            </b-form-invalid-feedback>
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
              :to="`/quyen/edit/${quyen.id}`"
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
      quyen: {
        tenQuyen: null,
      }
    };
  },
  validations: {
    quyen: {
      tenQuyen: {
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
      const res = await this.$http.get(`quyen/${this.id}`);
      this.quyen = res?.data || {};
    },
    async save() {
      this.$v.$touch()
      if (!this.$v.$invalid){
        await this.$http.put(`quyen/${this.id}`, this.quyen);
        this.$toast.success('Cập nhật thành công!');
        this.cancel();
      }
      
    },
    cancel() {
      this.$router.push(`/quyen/detail/${this.id}`);
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