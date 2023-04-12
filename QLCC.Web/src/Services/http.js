import axios from 'axios';
import store from '@/store';
import router from '@/router';
import Vue from 'vue';
import toast from 'vue-toast-notification';
// const baseURL = 'https://localhost:7284/api';
const API_URL = window.ApiUrl || 'API_URL';

const baseURL = `${API_URL}/api`;

const errorHandler = (error) => {
  if (error.response.status === 500) {
    toast.error(`${error.response.data.detail}`, {
      position: "top-center",
      autoClose: false,
      hideProgressBar: false,
      closeOnClick: true,
      pauseOnHover: true,
      draggable: true,
      progress: 0,
      });  
  }

  return Promise.reject({ ...error })
}
const HTTP = axios.create({ baseURL: baseURL })
const token_interceptor = HTTP.interceptors.request.use(
  config => {
    const access_token = getToken();
    
    config.headers.Authorization = `Bearer ${access_token}`;
    config.baseURL = baseURL;
    return config;
  },
  error => {
    return Promise.reject(error)
  }
)


// Add a response interceptor
HTTP.interceptors.response.use(function (response) {
  // Any status code that lie within the range of 2xx cause this function to trigger
  // Do something with response data
  return response;
}, function (error) {
  // Any status codes that falls outside the range of 2xx cause this function to trigger
  // Do something with response error
  Vue.$toast.error('Đã xảy ra lỗi, liên hệ quản trị viên!');
  // errorHandler(error);
  return Promise.reject(error);
});


const getToken = function() {


  let user = null;
  if(store.state.user){
    user = store.state.user;
  }else {
    user = localStorage.getItem("UserInfo");
  }
  if(user !== null) {
    if(user.expTime < Date.now()){
      router.push('/login');
      return;
    }else{
      return user.token;
    }
  }
}


export default HTTP;