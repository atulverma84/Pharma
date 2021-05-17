<template>
  <v-app>
      <v-app-bar app
                 color="white"
                 dark>

          <v-app-bar-nav-icon @click="drawer=!drawer" style="color:red"></v-app-bar-nav-icon>
          <v-img src='../src/images/PharmaLogistics_logo.png' 
                 style="position: absolute;
            left: 4.84%;
            right: 88.05%;
            top: 5%;
            bottom: 5;
            width: 136px;
            height: 56px"
                 >
          </v-img>
          <v-spacer></v-spacer>

          Pharma
      </v-app-bar>

      <v-main>
          <router-view></router-view>
          <v-navigation-drawer v-model="drawer" absolute temporary  app >
              <v-list>
                  <v-list-item v-for="item in items" :key="item.title" v-bind:to="item.to" link>
                      <v-list-item-icon>
                          <v-icon>{{ item.icon }}</v-icon>
                      </v-list-item-icon>

                      <v-list-item-content>
                          <v-list-item-title>{{ item.title }}</v-list-item-title>
                      </v-list-item-content>
                  </v-list-item>
              </v-list>
          </v-navigation-drawer>         
      </v-main>
  </v-app>
</template>

<script>
    //import PharmaDetails from './components/PharmaDetails';
    import router from './router'

export default {
  name: 'App',
  router,
  components: {
      
  },
        data: () => ({
            drawer: false,
            items: [
                { title: 'Calender', icon: 'mdi-view-dashboard', to: '/calender' },
                { title: 'PharmaDetails', icon: 'mdi-image', to: '/PharmaDetails' },
                { title: 'About', icon: 'mdi-help-box' },
            ],
            right: null  
        }),
      
};
</script>
