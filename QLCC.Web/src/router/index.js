import Vue from 'vue'
import VueRouter from 'vue-router'
import store from '../store/index'

import HomeView from '../views/HomeView.vue'
import AboutView from '../views/AboutView.vue'
import ListNhanVien from '../views/nhanvien/List.vue'
import CreateNhanVien from '../views/nhanvien/Create.vue'
import DetailNhanVien from '../views/nhanvien/Detail.vue'
import HistoryNhanVien from '../views/nhanvien/History.vue'
import AttendanceNhanVien from '../views/nhanvien/Attendance.vue'
import PayrollList from '../views/nhanvien/Payroll.vue'
import ListTaiKboan from '../views/taikhoan/List.vue'
import CreateTaiKboan from '../views/taikhoan/Create.vue'
import DetailTaiKboan from '../views/taikhoan/Detail.vue'
import ListQuyen from '../views/quyen/List.vue'
import CreateQuyen from '../views/quyen/Create.vue'
import DetailQuyen from '../views/quyen/Detail.vue'
import ListPrivilege from '../views/taikhoan/Privilege.vue'

import ListNghiPhep from '../views/nghiphep/List.vue'
import CreateNghiPhep from '../views/nghiphep/Create.vue'
import DetailNghiPhep from '../views/nghiphep/Detail.vue'

import ListLeave from '../views/nghiphep/List.vue'
import CreateLeave from '../views/nghiphep/Create.vue'



import AppVue from '@/App.vue'
import TheContainer from '@/components/TheContainer.vue'
import Login from '@/components/LoginView.vue'
import Register from '@/components/RegisterView.vue'

import PageNotFound from '@/components/PageNotFound.vue'

Vue.use(VueRouter)

const routes = [
{
  path: '/',
  redirect: '/home',
  name: 'default',
  component: TheContainer,
  meta: { requiresAuth: true, label: 'Trang chủ' },
  children: [
    {
      path: '/home',
      name: 'home',
      component: HomeView,
      redirect: '/nhanvien/list',
    },
    {
      path: '/nhanvien',
      name: 'nhanVien',
      component: {
        render(c) { return c('router-view') }
      },
      redirect: '/nhanvien/list',
      children: [
        {
          path: 'list',
          name: 'list',
          component: ListNhanVien,
          // only authenticated users can create posts
          meta: { requiresAuth: true }
        },
        {
          path: 'create',
          name: 'create',
          component: CreateNhanVien,
          // only authenticated users can create posts
          meta: { requiresAuth: true }
        },
        {
          path: 'detail/:id',
          component: DetailNhanVien,
          
          // anybody can read a post
          meta: { requiresAuth: false },
        },
        {
          path: 'edit/:id',
          component: DetailNhanVien,
          
          // anybody can read a post
          meta: { requiresAuth: false, isEdit: true },
        },
        {
          path: 'history/:id',
          component: HistoryNhanVien,
          
          // anybody can read a post
          meta: { requiresAuth: false },
        },
        {
          path: 'attendance/:id',
          component: AttendanceNhanVien,
          
          // anybody can read a post
          meta: { requiresAuth: false },
        },
        {
          path: 'payroll',
          component: PayrollList,
          
          // anybody can read a post
          meta: { requiresAuth: false },
        },
        
      ]
    },
    {
      path: '/nghiphep',
      name: 'nghiphep',
      component: {
        render(c) { return c('router-view') }
      },
      redirect: '/nghiphep/list',
      children: [
        {
          path: 'list',
          name: 'list',
          component: ListNghiPhep,
          // only authenticated users can create posts
          meta: { requiresAuth: true }
        },
        {
          path: 'create',
          name: 'create',
          component: CreateNghiPhep,
          // only authenticated users can create posts
          meta: { requiresAuth: true }
        },
        {
          path: 'detail/:id',
          component: DetailNghiPhep,
          
          // anybody can read a post
          meta: { requiresAuth: false },
        },
        {
          path: 'edit/:id',
          component: DetailNghiPhep,
          
          // anybody can read a post
          meta: { requiresAuth: false, isEdit: true, },
        },
      ]
    },
    {
      path: 'leave',
      component: ListLeave,
      
      // anybody can read a post
      meta: { requiresAuth: false },
    },
    {
      path: '/taikhoan',
      name: 'taikhoan',
      component: {
        render(c) { return c('router-view') }
      },
      redirect: '/taikhoan/list',
      children: [
        {
          path: 'list',
          name: 'list',
          component: ListTaiKboan,
          // only authenticated users can create posts
          meta: { requiresAuth: true }
        },
        {
          path: 'create',
          name: 'create',
          component: CreateTaiKboan,
          // only authenticated users can create posts
          meta: { requiresAuth: true }
        },
        {
          path: 'detail/:id',
          component: DetailTaiKboan,
          
          // anybody can read a post
          meta: { requiresAuth: false },
        },
        {
          path: 'edit/:id',
          component: DetailTaiKboan,
          
          // anybody can read a post
          meta: { requiresAuth: false, isEdit: true },
        },
        {
          path: 'privilege/:id',
          component: ListPrivilege,
          
          // anybody can read a post
          meta: { requiresAuth: false },
        },
      ]
    },
    {
      path: '/quyen',
      name: 'quyen',
      component: {
        render(c) { return c('router-view') }
      },
      redirect: '/quyen/list',
      children: [
        {
          path: 'list',
          name: 'list',
          component: ListQuyen,
          // only authenticated users can create posts
          meta: { requiresAuth: true }
        },
        {
          path: 'create',
          name: 'create',
          component: CreateQuyen,
          // only authenticated users can create posts
          meta: { requiresAuth: true }
        },
        {
          path: 'detail/:id',
          component: DetailQuyen,
          
          // anybody can read a post
          meta: { requiresAuth: false },
        },
        {
          path: 'edit/:id',
          component: DetailQuyen,
          
          // anybody can read a post
          meta: { requiresAuth: false, isEdit: true },
        },
        {
          path: 'privilege/:id',
          component: ListPrivilege,
          
          // anybody can read a post
          meta: { requiresAuth: false, isEdit: true },
        },
        
      ]
    },
  ]
},

{
  path: '/login',
  name: 'login',
  component: Login
},
{
  path: '/register',
  name: 'register',
  component: Register
},
{
    path: '*',
    component: PageNotFound
},


  
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})
router.beforeEach((to, from, next) => {
  console.log('router.app.$store', store)
  const requiresAuth = to.matched.some(x => x.meta.requiresAuth);
  const currentUser = router.app.$store.getters.isAuthenticated;
  if (requiresAuth && !currentUser) {
    sessionStorage.setItem('redirectPath', to.path);
    next('/login');
    return;
  } else if (requiresAuth && currentUser) {
    next();
  } else {
    next();
  }
});
export default router
