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
        debugger;
        localStorage.setItem('UserInfo', JSON.stringify(res?.data));
        store.dispatch('loadIdentity', res?.data);
       })
    },
}