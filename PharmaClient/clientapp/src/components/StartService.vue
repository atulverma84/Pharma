<template>
  <div>
    <!-- <v-container class="createSmall" outline> -->
    <div class="left-right-space">
      <!-- Back Button -->
      <span>
        <v-btn fab icon color="primary" top left @click="$router.go(-1)">
          <v-icon x-large>mdi-arrow-left-bold-circle-outline</v-icon> </v-btn
        >{{ this.jobTitle }}
      </span>
      <!-- End of Back Button -->
      <v-spacer style="margin-top: 2%" />

      <!-- <v-card> -->

      <!-- Tabs -->
      <v-tabs v-model="tab" height="100%" grow light icons-and-text>
        <v-tab
          v-for="tab in tabs"
          :key="tab"
          :id="'tab' + tab.id"
          @click="toggleTabs(tab)"
        >
          <span>
            <h4>
              <v-icon fab>{{ tab.icon }}</v-icon> {{ tab.name }}
            </h4>
          </span>
        </v-tab>
      </v-tabs>

      <br />

      <v-tabs-items v-model="tab" class="grey lighten-5 mb-6">
        <!-- Start Service Tab -->
        <v-tab-item>
          <v-container class="detailsContainer">
            <v-row justify="space-between">
              <v-col v-for="tile in tiles" :key="tile" md="4">
                <div>
                  <v-row max-height="40px">
                    <v-col md="2">
                      <v-avatar color="#B7DEFF">
                        <v-icon color="rgba(0, 99, 167, 1)">
                          {{ tile.icon }}</v-icon
                        >
                      </v-avatar>
                    </v-col>
                    <v-col>
                      <p class="boldHeading">{{ tile.title }}</p>
                      <p>{{ tile.value }}</p>
                    </v-col>
                  </v-row>
                </div>
              </v-col>
            </v-row>
          </v-container>

          <!-- Sub-caption -->
          <div id="subCaption">
            <h2>{{ this.subCaption }}</h2>
            <br />
          </div>
          <br />
          <!-- End of Sub-caption -->

          <!-- Start Service Button -->
          <div id="divStartService">
            <v-btn id="btnStartSvc" large dark @click="startService">
              Start Service
            </v-btn>
          </div>
          <!-- End of Start Service Button -->

          <br /><br />
        </v-tab-item>
        <!-- End of Start Service Tab -->

        <!-- Service Book Tab -->
        <v-tab-item>
          <service-book />
        </v-tab-item>
        <!-- End of Service Book Tab -->
      </v-tabs-items>
      <!-- End of Tabs -->
      <!-- </v-card> -->
    </div>
    <!-- </v-container> -->
  </div>
</template>

<script>
import ServiceBook from "./ServiceBook.vue";

export default {
  name: "StartService",
  components: {
    "service-book": ServiceBook,
  },
  data() {
    return {
      tab: null,
      activeTab: 1,
      tabs: [
        {
          id: 1,
          name: "Service Information",
          icon: "mdi-checkbox-marked-circle",
          isActive: true,
        },
        {
          id: 2,
          name: "Service Book",
          icon: "mdi-book-open-variant",
          isActive: false,
        },
      ],
      jobTitle: "Hospital A | Pharmacy 1",
      subCaption: "Scheduled Service: Full Onsite Service",
      tiles: [
        {
          index: 0,
          title: "Facility Name:",
          value: "Pharmacy B",
          icon: "mdi-domain",
        },
        {
          index: 1,
          title: "Service Time:",
          value: "3:00PM - 4:00PM",
          icon: "mdi-clock",
        },
        {
          index: 2,
          title: "Customer Code:",
          value: "2706 W Flournoy St Suite 500 Chicago, Illinois(IL), 60612",
          icon: "mdi-pound-box",
        },
        {
          index: 3,
          title: "Address:",
          value: "2706 W Flournoy St Suite 500 Chicago, Illinois(IL), 60612",
          icon: "mdi-map-marker",
        },
        {
          index: 4,
          title: "Scheduling Contact:",
          value: "Chris Barnes",
          icon: "mdi-account",
        },
        {
          index: 5,
          title: "Phone:",
          value: "(773) 826-0000",
          icon: "mdi-phone",
        },
      ],
    };
  },
  mounted() {
    this.activeTab = 1;
  },
  methods: {
    backToCalender() {
      console.log("Return to Calender called.");
    },
    startService() {
      console.log("Start Service clicked!");
      alert("Service Started!");
    },
    toggleTabs(tab) {
      console.log("Selected Tab:" + tab.name);
    },
  },
};
</script>

<style>
h4 {
  text-transform: none;
}

h5 {
  position: static;
  width: 538px;
  height: 42px;
  left: calc(50% - 538px / 2);
  top: calc(50% - 42px / 2);
  /* desktop/h5 */
  font-family: Arial;
  font-style: normal;
  font-weight: bold;
  font-size: 20px;
  line-height: 150%;
  display: flex;
  align-items: center;
  justify-content: center;
  letter-spacing: 0.5px;

  /* text/body */
  color: #383839;
}

p {
  font-family: Arial;
  font-style: normal;
  font-size: 14px;
  line-height: 100%;
  display: flex;
  align-items: center;
  letter-spacing: 0.5px;
  color: #111111;
}

#btnStartSvc {
  background-color: rgba(0, 99, 167, 1);
  padding: 12px 60px;
  position: static;
  left: calc(50% - 300px / 2);
  top: calc(50% - 53px / 2);
}

.btnReturn {
  display: flex;
  align-content: center;
  justify-content: center;
  border-radius: 50%;
  border-width: 2px;
  border: 2px;
  left: 12.5%;
  right: 12.5%;
  top: 12.5%;
  bottom: 12.5%;

  /* color/accent */
  border: 2px solid #0063a7;
}

.divStartSvc {
  display: flex;
  flex-direction: column;
  align-items: flex-start;
  padding: 20px;
  position: static;
  width: 100%;
  max-height: 50%;
  left: 0px;
  top: 94px;

  /* color/accent/background */
  background: #f7f9fe;
  border-radius: 8px;

  /* Inside Auto Layout */
  flex: none;
  order: 1;
  align-self: stretch;
  flex-grow: 0;
  margin: 40px 0px;
}

#divStartService {
  display: flex;
  align-items: center;
  justify-content: center;
}

#subCaption {
  display: flex;
  align-items: center;
  justify-content: center;
}

.detailsContainer {
  margin: 20px auto;
}

.boldHeading {
  font-family: Arial;
  font-style: normal;
  font-weight: bold;
  font-size: 17px;
  line-height: 160%;
  display: flex;
  align-items: center;
  letter-spacing: 0.5px;
  color: #111111;
}

.v-tab.v-tab--active {
  background-color: rgba(0, 99, 167, 1);
  color: white;
}

.v-tab {
  background-color: rgba(239, 240, 246, 1);
  color: #76777a;
}

.v-tab--active h4 {
  color: white;
}

.left-right-space {
  margin-left: 5%;
  margin-right: 5%;
  margin-top: 2%;
}
</style>