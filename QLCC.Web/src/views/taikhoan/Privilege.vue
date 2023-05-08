<template>
  <div class="row">
    <div class="col-md-12">
      <div class="card-box">
        <h4 class="card-title">
          Phân quyền cho <b>{{ user.fullName }}</b>
        </h4>
        <form action="#">
          <b-form-group
            v-slot="{ ariaDescribedby }"
            label="Danh sách quyền hệ thống:"
          >
            <b-form-checkbox-group
              id="checkbox-group-1"
              v-model="selected"
              :options="roles"
              :aria-describedby="ariaDescribedby"
              name="flavour-1"
            />
          </b-form-group>
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
              class="m-l-1"
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
      user: {
        fullName: null,
      },
      selected: [], // Must be an array reference!
      roles: [],
    };
  },
  computed: {
    id() {
      return this.$route.params.id;
    },
    isEdit() {
      return this.$route.meta.isEdit;
    }
  },
  async created() {
    await this.getData();
    await this.getRoles();
  },
  methods: {
    async getData() {
      const res = await this.$http.get(`user/${this.id}`);
      this.user = res?.data || {};
    },
    async getRoles() {
      const res = await this.$http.get(`role/list`);
      this.roles = res?.data.map(x => { return { text: x.name, value: x.id} }) || {};
      this.selected = this.user.userRoles?.map(x=>x.roleId) || [];
    },
    async save() {
      await this.$http.post(`userRole/${this.id}`, this.selected);
        this.$toast.success('Cập nhật thành công!');
        this.cancel();
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