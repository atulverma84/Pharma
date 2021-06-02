import Vue from 'vue';
import VueRouter from 'vue-router'

Vue.use(VueRouter)

import calender from '../components/calender'
import PharmaDetails from '../components/PharmaDetails'
import StartService from '../components/StartService'
import ServiceBook from '../components/ServiceBook'
import Handle404Exception from '../components/Exceptions/Handle404Exception'
import Handle500Exception from '../components/Exceptions/Handle500Exception'

const routes = [
    {
        component: calender,
        name: "calender",
        path: "/"
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
        component: ServiceBook,
        name: "ServiceBook",
        path: "/ServiceBook"
    },
    { 
        component: Handle500Exception,
        name: 'Handle500Exception', 
        path: '/error',
    },
    {
        path: '/PharmaDetails',
        name: 'PharmaDetails',
        component: PharmaDetails
    },
    {
        path: '*',
        name: 'Handle404Exception',   
        component: Handle404Exception
    }
];

export default new VueRouter({
    routes
})

