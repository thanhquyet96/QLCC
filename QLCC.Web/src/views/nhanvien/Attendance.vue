<template>
  <div>
    <div class="row">
      <div class="col-sm-12">
        <h4 class="page-title">
          Chấm công
        </h4>
      </div>
    </div>
    <div class="row filter-row">
      <div class="col-sm-6 col-md-3">
        <div
          class="form-group form-focus select-focus"
          style="margin-bottom: -10px; width: 400px;"
        >
          <h2 class="text-left">
            Xin chào, {{ user?.fullName }}
          </h2>
        </div>
        <p
          class="focus-label"
          style="text-align: left;"
        >
          Hà Nội, ngày {{ new Date().toLocaleDateString() }}
        </p>
      </div>

      <div class="col-sm-6 col-md-3">
        <!-- <a
          href="#"
          class="btn btn-success btn-block"
        > Thực hiện chấm công </a> -->
      </div>
    </div>

    <div class="row">
      <div class="col-lg-3">
        <b-button
          v-if="!isCheckIn"
          variant="success"
          style="height: 60px;"
          @click="chamCong(false)"
        >
          Thực hiện chấm công
        </b-button>
        <b-button
          v-else
          variant="danger"
          style="height: 60px;"
          @click="chamCong(true)"
        >
          Chấm công về
        </b-button>
      </div>
    </div>
  </div>
</template>

  <script>
    import TableComponentVue from "@/components/TableComponent.vue"
import { mapState } from 'vuex';

    export default {
    name: 'ListView',
    components: {
    
    },
    data() {
      return {
        isCheckIn: false,
      };
    },
    computed: {
      ...mapState(['user'])
    },
    created() {
      this.checkCheckInCheckOut();
    },
    methods: {
      async chamCong(checkOut) {
        await this.$http.post(`timeKeep?checkOut=${checkOut}`);
        await this.checkCheckInCheckOut();
        this.$toast.success('Chấm công thành công!');
      },
      async checkCheckInCheckOut() {
        const { data } = await this.$http.get('timeKeep/is-checkin');
        this.isCheckIn = data;
      }
    }
  }
  </script>
  <style scoped>
    .form-group {
        text-align: left;
    }
    select{
      width: 100%;
    }
  </style>