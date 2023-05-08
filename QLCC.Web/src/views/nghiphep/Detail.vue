<template>
  <div class="row">
    <div class="col-md-12">
      <div class="card-box">
        <h4 class="card-title">
          Thông tin nghỉ phép
        </h4>
        <form action="#">
          <b-form-group
            label="Người phê duyệt:"
          >
            <b-form-select
              v-model="nghiPhep.approveUserId"
              :disabled="!isEdit"
              :options="nguoiPheDuyets"
              class="mb-3"
              value-field="item"
              text-field="name"
              disabled-field="notEnabled"
              :state="isEdit && ($v.nghiPhep.approveUserId.$dirty ? !$v.nghiPhep.approveUserId.$error : null)"
            />
            <b-form-invalid-feedback>
              Trường này không được để trống
            </b-form-invalid-feedback>
          </b-form-group>

          <b-form-group
            label="Hình thức nghỉ:"
          >
            <b-form-select
              v-model="nghiPhep.leaveForm"
              :disabled="!isEdit"
              :options="leaveForms"
              class="mb-3"
              value-field="item"
              text-field="name"
              disabled-field="notEnabled"
              :state="isEdit && ($v.nghiPhep.leaveForm.$dirty ? !$v.nghiPhep.leaveForm.$error : null)"
            />
            <b-form-invalid-feedback>
              Trường này không được để trống
            </b-form-invalid-feedback>
          </b-form-group>

          <b-form-group
            label="Loại nghỉ:"
          >
            <b-form-select
              v-model="nghiPhep.leaveType"
              :disabled="!isEdit"
              :options="optionsLeaveType"
              class="mb-3"
              value-field="item"
              text-field="name"
              disabled-field="notEnabled"
              :state="isEdit && ($v.nghiPhep.leaveType.$dirty ? !$v.nghiPhep.leaveType.$error : null)"
            />
            <b-form-invalid-feedback>
              Trường này không được để trống
            </b-form-invalid-feedback>
          </b-form-group>

          <b-form-group
            label="Ngày nghỉ:"
          >
            <b-form-input
              v-model="$v.nghiPhep.createdForDay.$model"
              :disabled="!isEdit"
              type="date"
              :state="isEdit && ($v.nghiPhep.createdForDay.$dirty ? !$v.nghiPhep.createdForDay.$error : null)"
            />
            <!-- <datepicker
              :value="$v.nghiPhep.createdForDay.$model"
              :state="($v.nghiPhep.createdForDay.$model !== null) && !$v.nghiPhep.createdForDay.$error"
            /> -->
            <b-form-invalid-feedback>
              Trường này không được để trống
            </b-form-invalid-feedback>
          </b-form-group>
          <div class="form-group">
            <label>Lý do</label>
            <b-form-textarea
              v-model="$v.nghiPhep.reason.$model"
              :disabled="!isEdit"
              :state="isEdit && ($v.nghiPhep.reason.$dirty ? !$v.nghiPhep.reason.$error : null)"
              placeholder="Enter something..."
              rows="3"
              max-rows="6"
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
              :to="`/leave/edit/${nghiPhep.id}`"
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
        leaveType: null,
        approveUserId: null,
        createdForDay: null,
        reason: null,
        leaveForm: null,
      },
      nguoiPheDuyets: [],
      leaveForms: [
        { item: 1, name: 'Nghỉ phép' },
        { item: 2, name: 'Nghỉ không lương' },
      ],
      optionsLeaveType: [
        { item: 2, name: 'Nghỉ cả ngày' },
        { item: 3, name: 'Nghỉ sáng' },
        { item: 4, name: 'Nghỉ chiều' },
      ]
    };
  },
  validations: {
    
    nghiPhep: {
      approveUserId: {
        required
      },
      leaveType: {
        required
      },
      leaveForm: {
        required
      },
      createdForDay: {
        required,
      },
      reason: {
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
  async created() {
    await this.getDetail();

    await this.loadUsers();
  },
  methods: {
    async save() {
      this.$v.$touch()
      if (!this.$v.$invalid){
        await this.$http.put(`leave/${this.id}`, this.nghiPhep);
        this.$toast.success('Cập nhật thành công!');
        this.cancel();
      }
    },
    cancel() {
      this.$router.push(`/leave`);
    },
    async getDetail() {
      const { data } = await this.$http.get(`leave/${this.id}`);
      this.nghiPhep = data || [];
      this.nghiPhep.createdForDay = data.createdForDay?.split('T')[0];
    },
    async loadUsers() {
      const { data } = await this.$http.get('user/list');
      this.nguoiPheDuyets = data.map(x => { 
        return {
          item: x.id,
          name: x.fullName,
        }
      });
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