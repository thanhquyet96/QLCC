<template>
  <div class="main-wrapper account-wrapper">
    <div class="account-page">
      <div class="account-center">
        <div class="account-box">
          <form
            action="#"
            class="form-signin"
            @submit.prevent="submitForm"
          >
            <div class="account-logo">
              <a href="index.html"><img
                src="assets/img/logo-dark.png"
                alt=""
              ></a>
            </div>
            <b-form-group
              label="Tài khoản"
            >
              <b-form-input
                v-model="$v.user.Username.$model"
                :state="($v.user.Username.$model !== null) && !$v.user.Username.$error"
              />
              <b-form-invalid-feedback>
                Trường này không được để trống
              </b-form-invalid-feedback>
            </b-form-group>
            <b-form-group
              label="Mật khẩu"
            >
              <b-form-input
                v-model="$v.user.Password.$model"
                :state="($v.user.Password.$model !== null) && !$v.user.Password.$error"
                type="password"
              />
              <b-form-invalid-feedback>
                Trường này không được để trống
              </b-form-invalid-feedback>
            </b-form-group>
            <div class="form-group text-right">
              <a href="forgot-password.html">Quên mật khẩu?</a>
            </div>
            <div class="form-group text-center">
              <button
                type="submit"
                class="btn btn-primary account-btn"
              >
                Đăng nhập
              </button>
            </div>
            <div class="text-center register-link">
              Bạn chưa có tài khoản? 
              <router-link to="/register">
                Đăng ký
              </router-link>
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
  props: {
    msg: String
  },
  data() {
    return {
        user:{
            Username: null,
            Password: null
        }
    };
  },
  validations: {
    user: {
      Username: {
        required
      },
      Password: {
        required
      }
    }
  },
  methods: {
    submitForm() {
      this.$v.$touch()
      if (!this.$v.$invalid){
        //    const user = ;
        const vm = this;
           this.$services.login(this.user).then((res) => {
            location.href = "/";
           });
        }
    }
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
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
