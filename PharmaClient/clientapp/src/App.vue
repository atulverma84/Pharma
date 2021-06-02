<template>
    <v-app>
        <v-app-bar app color="white" dark>
            <v-img src="../src/images/PharmaLogistics_logo.png"
                   style="        position: absolute;
        left: 4.84%;
        right: 88.05%;
        top: 5%;
        bottom: 5px;
        width: 136px;
        height: 56px;
        cursor: pointer;
    "
                   @click="goToHome()">
            </v-img>
       
            <v-spacer></v-spacer>
            <v-toolbar-items>
                <v-btn text color="black">
                    222 Forms
                </v-btn>
                <v-divider vertical color="#84C6FF"></v-divider>
                <!--<v-btn text color="black">
            Inventory Report
            <v-icon small class="ml-2" style="font-size:12px">
                mdi-rotate-180 mdi-triangle
            </v-icon>
        </v-btn>-->

                <v-menu offset-y>
                    <template v-slot:activator="{ on, attrs }">
                        <v-btn text color="black"
                               v-bind="attrs"
                               v-on="on">
                            Inventory Report
                            <v-icon small class="ml-2" style="font-size:12px">
                                mdi-rotate-180 mdi-triangle
                            </v-icon>
                        </v-btn>
                    </template>
                    <v-list>
                        <v-list-item link class="listHover">
                            <v-list-item-title>
                                <v-icon medium class="ml-2 mr-2" color="rgb(25, 118, 210)">
                                    mdi-file-pdf
                                </v-icon> Download Pdf
                            </v-list-item-title>
                        </v-list-item>
                        <v-list-item link class="listHover">
                            <v-list-item-title>
                                <v-icon medium class="ml-2 mr-2" color="rgb(25, 118, 210)">
                                    mdi-email
                                </v-icon>
                                Email
                            </v-list-item-title>
                        </v-list-item>
                        <v-list-item link class="listHover">
                            <v-list-item-title>
                                <v-icon medium class="ml-2 mr-2" color="rgb(25, 118, 210)">
                                    mdi-printer
                                </v-icon>
                                Print
                            </v-list-item-title>
                        </v-list-item>
                    </v-list>
                </v-menu>
                <v-divider vertical color="#84C6FF"></v-divider>
                <v-btn text color="black">
                    Shipping Label
                </v-btn>
                <v-divider vertical></v-divider>
            </v-toolbar-items>

        </v-app-bar>
        <v-main>
            <router-view></router-view>
        </v-main>
        <div style="width: 100%;justify-content: center;text-align: center;color: white;background-color: rgb(25, 118, 210)" class="mt-4 pa-2">
            <strong style="float:right"> <v-icon medium color="white">mdi-copyright</v-icon> {{ new Date().getFullYear() }} Pharma Logistics</strong>
        </div>
       
    </v-app>
</template>
<style scoped>
    .listHover:hover {
        background-color: rgb(247, 249, 254)!important;
    }
</style>
<script>
//import PharmaDetails from './components/PharmaDetails';
import router from "./router";

export default {
  name: "App",
  router,
  components: {},
        data: () => ({}),
        methods: {
            goToHome() {
                this.$router.push('/');
            }
        }
};
</script>
