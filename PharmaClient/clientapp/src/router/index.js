import Vue from 'vue';
import VueRouter from 'vue-router'

Vue.use(VueRouter)
import calender from '../components/calender'
import PharmaDetails from '../components/PharmaDetails'
import StartService from '../components/StartService'
import ServiceBook from '../components/ServiceBook'
import ViewOnSite from '../components/ViewOnSite'
import OnSiteApp from '../components/OnSiteApp'
import ModalView from '../components/ModalView'
import OrderEntryList from '../components/OrderEntryList'
import ProductList from '../components/ProductList'

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
        component: OnSiteApp,
        name: "OnSiteApp",
        path: "/OnSiteApp"
    },
    {
        component: ServiceBook,
        name: "ServiceBook",
        path: "/ServiceBook"
    },
    {
        component: ViewOnSite,
        name: "ViewOnSite",
        path: "/ViewOnSite"
    },
    {
        component: ModalView,
        name: "Modal",
        path: "/ModalView"
    },
    {
        component: OrderEntryList,
        name: "OrderEntryList",
        path: "/OrderEntry"
    },
    {
        component: ProductList,
        name: "ProductList",
        path: "/ProductList"
    }
];

export default new VueRouter({
    routes
})

