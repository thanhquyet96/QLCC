import axios from 'axios';
const baseURL = 'https://localhost:7284/api';
import store from '../store/index';
axios.defaults.headers.common = {
    "X-Requested-With": "XMLHttpRequest",
    "Content-Type": "application/x-www-form-urlencoded",
    'Accept'       : 'application/json',
    // 'Content-Type' : 'application/json',
  };
export default {
    login: (user) => {
       return axios.post(`${baseURL}/auth/login`, user).then((res) => {
        localStorage.setItem('UserInfo', JSON.stringify(res?.data));
        store.dispatch('loadIdentity', res?.data);
       })
    },
    logout: () => {
      return axios.post(`${baseURL}/auth/logout`).then((res) => {
       localStorage.removeItem('UserInfo');
       store.dispatch('loadIdentity', {});
      })
   },
   register: (user) => {
      return axios.post(`${baseURL}/auth/register`, user);
   }
}