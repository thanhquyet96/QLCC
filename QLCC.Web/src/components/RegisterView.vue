<template>
  <div class="main-wrapper account-wrapper">
    <div class="account-page">
      <div class="account-center">
        <div class="account-box">
          <form
            @submit.prevent="onSubmit"
            class="form-signin"
          >
            <div class="account-logo">
              <a href="index.html"><img
                src="assets/img/logo-dark.png"
                alt=""
              ></a>
            </div>
            <b-form-group
              label="Họ và tên"
            >
              <b-form-input
                v-model="$v.user.fullName.$model"
                :state="($v.user.fullName.$model !== null) && !$v.user.fullName.$error"
              />
              <b-form-invalid-feedback>
                Trường này không được để trống
              </b-form-invalid-feedback>
            </b-form-group>
            <b-form-group
              label="Tài khoản"
            >
              <b-form-input
                v-model="$v.user.userName.$model"
                :state="($v.user.userName.$model !== null) && !$v.user.userName.$error"
              />
              <b-form-invalid-feedback>
                Trường này không được để trống
              </b-form-invalid-feedback>
            </b-form-group>

            <b-form-group
              label="Mật khẩu"
            >
              <b-form-input
                v-model="$v.user.password.$model"
                :state="($v.user.password.$model !== null) && !$v.user.password.$error"
              />
              <b-form-invalid-feedback>
                Trường này không được để trống
              </b-form-invalid-feedback>
            </b-form-group>
            <b-form-group
              label="Nhập lại mật khẩu"
            >
              <b-form-input
                v-model="$v.user.rePassword.$model"
                :state="($v.user.rePassword.$model !== null) && !$v.user.rePassword.$error"
              />
              <b-form-invalid-feedback>
                Trường này không được để trống
              </b-form-invalid-feedback>
            </b-form-group>
            <div class="form-group text-center">
              <button
                class="btn btn-primary account-btn"
              >
                Đăng ký
              </button>
            </div>
            <div class="text-center register-link">
              Bạn có tài khoản? <a href="/login">Đăng nhập</a>
            </div>
          </form>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { required, minLength, between } from 'vuelidate/lib/validators'

export default {
  name: 'LoginView',
  data() {
    return {
      user: {
        fullName: null,
        userName: null,
        password: null,
        rePassword: null,
      }
    };
  },
  validations: {
    user: {
      fullName: {
        required
      },
      userName: {
        required
      },
      password: {
        required
      },
      rePassword: {
        required,
      },
    }
  },
  methods: {
    async onSubmit() {
      this.$v.$touch()
      if (!this.$v.$invalid)
      {
        this.$services.register(this.user).then(() => {
          this.$router.push('/login');
        });
      }
    }
  }
}
</script>

<style scoped>
  /*  h3 {
        margin: 40px 0 0;
    }

    ul {
        list-style-type: none;
        padding: 0;
    }

    li {
        display: inline-block;
        margin: 0 10px;
    }

    a {
        color: #42b983;
    }*/
</style>
