// define app store actions names
export const ACTION_APP_INCREMENT = 'ActionAppIncrement1'
export const ACTION_APP_DECREMENT = 'ActionAppDecrement'

// define app store mutations names
const INCREMENT_VALUE = 'IncrementValue1'

// initial app state
const state = {
  size: '',
  strength: '',
  dosage: '',
  controlnumber:'',
  manufacturer:'',
  returnable:'',
  repacked:''
}

const getters = {
  getState(state) {
    return state;
  }
}

// app store actions
const actions = {
  [ACTION_APP_INCREMENT] (context, payload) {
    context.commit(INCREMENT_VALUE, {pharma:payload});
  }
}

// app store mutations
const mutations = {
  [INCREMENT_VALUE] (state, payload) {
     state.size = payload.pharma.size,
    state.strength =  payload.pharma.strength,
    state.dosage = payload.pharma.dosage,
    state.controlnumber = payload.pharma.controlnumber,
    state.manufacturer = payload.pharma.manufacturer,
    state.returnable = payload.pharma.returnable,
    state.repacked = payload.pharma.repacked
  }
  
}

export default {
    state,
    actions,
    mutations,
    getters
}