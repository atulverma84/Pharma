import Vue from 'vue'
import Vuex from 'vuex'
import appStore from './app.store'

Vue.use(Vuex)

const store = new Vuex.Store({
  debug: false,
  modules: {
    appStore
  },
  
})

export default store