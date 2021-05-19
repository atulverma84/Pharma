import Vue from 'vue';
import VueRouter from 'vue-router'

Vue.use(VueRouter)

import calender from '../components/calender'
import PharmaDetails from '../components/pharmaDetails'
import StartService from '../components/StartService'

const routes = [
    {
        component: calender,
        name: "calender",
        path: "/calender"
    },
    {
        component: PharmaDetails,
        name: "PharmaDetails",
        path: "/pharmaDetails"
    },
    {
        component: StartService,
        name: "StartService",
        path: "/StartService"
    },
    {
        path: '/',
        name: 'PharmaDetails',
        component: PharmaDetails
    }
];

export default new VueRouter({
    routes
})

