import Vue from 'vue';
import VueRouter from 'vue-router'

Vue.use(VueRouter)

import calender from '../components/calender'
import pharmaDetails from '../components/PharmaDetails'
import StartService from '../components/StartService';

const routes = [
    {
        component: calender,
        name: "calender",
        path: "/calender"
    },
    {
        component: pharmaDetails,
        name: "PharmaDetails",
        path: "/PharmaDetails"
    },
    {
        component: StartService,
        name: "StartService",
        path: "/StartService"
    },
    {
        path: '/',
        name: 'PharmaDetails',
        component: pharmaDetails
    }
];

export default new VueRouter({
    routes
})

