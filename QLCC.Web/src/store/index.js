import Vue from 'vue'
import Vuex from 'vuex'
Vue.use(Vuex)

export default new Vuex.Store({
  state: {
    user: null,
    isAuthenticated: false,
  },
  getters: {
    isAuthenticated(state) {
      return state.user !== null;
    }
  },
  mutations: {
    SET_USER(state, value) {
      state.user = value;
    }
  },
  actions: {
    loadIdentity({commit}, value){
      const user = localStorage.getItem('UserInfo');
      if(user == null) {
        commit('SET_USER', value);
      }
      else{
        commit('SET_USER', JSON.parse(user));
      }
    }
  },
  modules: {
  }
})
