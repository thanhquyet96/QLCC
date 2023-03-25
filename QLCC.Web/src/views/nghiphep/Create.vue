<template>
  <div class="row">
    <div class="col-md-12">
      <div class="card-box">
        <h4 class="card-title">
          Thêm mới nghỉ phép
        </h4>
        <form action="#">
          <b-form-group
            label="Người phê duyệt:"
          >
            <b-form-select
              v-model="nghiPhep.nguoiPheDuyet"
              :options="nguoiPheDuyets"
              class="mb-3"
              value-field="item"
              text-field="name"
              disabled-field="notEnabled"
              :state="($v.nghiPhep.nguoiPheDuyet.$model !== null) && !$v.nghiPhep.nguoiPheDuyet.$error"
            />
            <b-form-invalid-feedback>
              Trường này không được để trống
            </b-form-invalid-feedback>
          </b-form-group>

          <b-form-group
            label="Hình thức nghỉ:"
          >
            <b-form-select
              v-model="nghiPhep.hinhThucNghi"
              :options="hinhThucNghis"
              class="mb-3"
              value-field="item"
              text-field="name"
              disabled-field="notEnabled"
              :state="($v.nghiPhep.hinhThucNghi.$model !== null) && !$v.nghiPhep.hinhThucNghi.$error"
            />
            <b-form-invalid-feedback>
              Trường này không được để trống
            </b-form-invalid-feedback>
          </b-form-group>

          <b-form-group
            label="Loại nghỉ:"
          >
            <b-form-select
              v-model="nghiPhep.loaiNghi"
              :options="optionsLeaveType"
              class="mb-3"
              value-field="item"
              text-field="name"
              disabled-field="notEnabled"
              :state="($v.nghiPhep.loaiNghi.$model !== null) && !$v.nghiPhep.loaiNghi.$error"
            />
            <b-form-invalid-feedback>
              Trường này không được để trống
            </b-form-invalid-feedback>
          </b-form-group>

          <b-form-group
            label="Ngày nghỉ:"
          >
            <b-form-input
              v-model="$v.nghiPhep.taoChoNgay.$model"
              type="date"
              :state="($v.nghiPhep.taoChoNgay.$model !== null) && !$v.nghiPhep.taoChoNgay.$error"
            />
            <!-- <datepicker
              :value="$v.nghiPhep.taoChoNgay.$model"
              :state="($v.nghiPhep.taoChoNgay.$model !== null) && !$v.nghiPhep.taoChoNgay.$error"
            /> -->
            <b-form-invalid-feedback>
              Trường này không được để trống
            </b-form-invalid-feedback>
          </b-form-group>
          <div class="form-group">
            <label>Lý do</label>
            <b-form-textarea
              v-model="$v.nghiPhep.lyDo.$model"
              :state="($v.nghiPhep.lyDo.$model !== null) && !$v.nghiPhep.lyDo.$error"
              placeholder="Enter something..."
              rows="3"
              max-rows="6"
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
      nghiPhep: {
        loaiNghi: null,
        nguoiPheDuyet: null,
        taoChoNgay: null,
        lyDo: null,
        hinhThucNghi: null,
      },
      nguoiPheDuyets: [
          { item: 1, name: 'Admin 1' },
          { item: 2, name: 'Admin 2' },
          { item: 3, name: 'Admin 3' },
        ],
      optionsLeaveType: [
         { item: 1, name: 'Nghỉ phép' },
         { item: 2, name: 'Nghỉ không lương' },
      ],
      hinhThucNghis: [
        { item: 2, name: 'Nghỉ cả ngày' },
        { item: 3, name: 'Nghỉ sáng' },
        { item: 4, name: 'Nghỉ chiều' },
      ]
    };
  },
  validations: {
    
    nghiPhep: {
      nguoiPheDuyet: {
        required
      },
      loaiNghi: {
        required
      },
      hinhThucNghi: {
        required
      },
      taoChoNgay: {
        required,
      },
      lyDo: {
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
        await this.$http.post(`nghiphep`, this.nghiPhep);
        this.$toast.success('Thêm mới thành công!');
        this.cancel();
      }
      
    },
    cancel() {
      this.$router.push(`/nghiphep`);
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