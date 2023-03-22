import Vue from 'vue'
import App from './App.vue'
import router from './router'
import store from './store'
import Vuex from 'vuex'
import VueToast from 'vue-toast-notification';
import Vuelidate from 'vuelidate'

// Import one of the available themes
//import 'vue-toast-notification/dist/theme-default.css';
import 'vue-toast-notification/dist/theme-bootstrap.css';

Vue.config.productionTip = false
import { BootstrapVue, IconsPlugin } from 'bootstrap-vue'
import Datepicker from 'vuejs-datepicker';
import Services from './Services/services';
import HTTP from './Services/http';
// Import Bootstrap and BootstrapVue CSS files (order is important)
// import 'bootstrap/dist/css/bootstrap.css'
// import 'bootstrap-vue/dist/bootstrap-vue.css'

// Make BootstrapVue available throughout your project
Vue.use(BootstrapVue)
// Optionally install the BootstrapVue icon components plugin
Vue.use(IconsPlugin)
Vue.use(VueToast, {
  position: 'bottom'
});

Vue.use(Vuelidate)

// eslint-disable-next-line vue/multi-word-component-names
Vue.component('Datepicker', Datepicker)
Vue.prototype.$services = Services;
Vue.prototype.$http = HTTP;

Vue.use(Vuex)

store.dispatch('loadIdentity');

new Vue({
  router,
  store,
  render: h => h(App),
}).$mount('#app')
