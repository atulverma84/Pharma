<template>
  <div>
    <div id="svcBook" class="light-background mb-6 pt-10 pl-10 pr-10" fluid>
      <h5>General Stats:</h5>
      <br />
      <v-spacer></v-spacer>

      <!-- General Stats Container -->
      <!-- Stats #1 - Average number of boxes -->
      <v-row justify="space-between">
        <v-col md="1" class="text-right" style="margin-left: -4%">
          <v-avatar color="#B7DEFF">
            <v-icon color="rgba(0, 99, 167, 1)"
              >mdi-package-variant-closed</v-icon
            >
          </v-avatar>
        </v-col>
        <v-col md="2">
          <p style="font-weight: bold">{{ this.numberOfBoxes }}</p>
          <p style="font-weight: bold">Average No. of Boxes</p>
        </v-col>
        <!-- End of Stats #1 - Average number of boxes -->

        <!-- Stats #2 - Average number of pallets -->
        <v-col md="1" class="text-right">
          <v-avatar color="#B7DEFF">
            <v-icon color="rgba(0, 99, 167, 1)">mdi-package-variant</v-icon>
          </v-avatar>
        </v-col>
        <v-col md="2">
          <p style="font-weight: bold">{{ this.avgNumOfPallets }}</p>
          <p style="font-weight: bold">Average No. of Pallets</p>
        </v-col>
        <!-- End of Stats #2 - Average number of pallets -->

        <!-- Stats #3 - Average number of controls -->
        <v-col md="1" class="text-right">
          <v-avatar color="#B7DEFF">
            <v-icon color="rgba(0, 99, 167, 1)">mdi-file</v-icon>
          </v-avatar>
        </v-col>
        <v-col md="2">
          <p style="font-weight: bold">{{ this.avgNumOfControls }}</p>
          <p style="font-weight: bold">Average No. of Controls</p>
        </v-col>
        <!-- End of Stats #3 - Average number of controls -->

        <!-- Stats #4 - Average time spent -->
        <v-col md="1" class="text-right">
          <v-avatar color="#B7DEFF">
            <v-icon color="rgba(0, 99, 167, 1)">mdi-clock</v-icon>
          </v-avatar>
        </v-col>
        <v-col md="2">
          <p style="font-weight: bold">{{ this.avgTimeSpent }} hours</p>
          <p style="font-weight: bold">Average Time Spent</p>
        </v-col>
        <!-- End of Stats #4 - Average time spent -->
      </v-row>
      <!-- End of General Stats Container -->
    </div>

    <v-spacer></v-spacer>

    <div id="panels" class="mb-6" fluid>
      <!-- Service Book Section -->
      <v-expansion-panels>
        <v-expansion-panel class="mt-5">
          <v-expansion-panel-header
            class="light-background"
            @click="headerClicked = !headerClicked"
          >
            <h5 :class="{ blueHeader: headerClicked }">Contacts</h5>
            <template v-slot:actions>
              <v-icon color="rgba(0, 99, 167, 1)"> mdi-plus </v-icon>
            </template>
          </v-expansion-panel-header>
          <v-expansion-panel-content class="light-background">
            <Contacts />
          </v-expansion-panel-content>
        </v-expansion-panel>

        <v-expansion-panel class="mt-5">
          <v-expansion-panel-header
            class="light-background"
            @click="headerClicked = !headerClicked"
          >
            <h5 :class="{ blueHeader: headerClicked }">Hours of Operation</h5>
            <template v-slot:actions>
              <v-icon color="rgba(0, 99, 167, 1)"> mdi-plus </v-icon>
            </template>
          </v-expansion-panel-header>
          <v-expansion-panel-content class="light-background">
            <HoursOfOperation />
          </v-expansion-panel-content>
        </v-expansion-panel>

        <v-expansion-panel class="mt-5">
          <v-expansion-panel-header
            class="light-background"
            @click="headerClicked = !headerClicked"
          >
            <h5 :class="{ blueHeader: headerClicked }">Pre-Service</h5>
            <template v-slot:actions>
              <v-icon color="rgba(0, 99, 167, 1)"> mdi-plus </v-icon>
            </template>
          </v-expansion-panel-header>
          <v-expansion-panel-content class="light-background">
            <PreService />
          </v-expansion-panel-content>
        </v-expansion-panel>

        <v-expansion-panel class="mt-5">
          <v-expansion-panel-header
            class="light-background"
            @click="headerClicked = !headerClicked"
          >
            <h5 :class="{ blueHeader: headerClicked }">Service</h5>
            <template v-slot:actions>
              <v-icon color="rgba(0, 99, 167, 1)"> mdi-plus </v-icon>
            </template>
          </v-expansion-panel-header>
          <v-expansion-panel-content class="light-background">
            <Service />
          </v-expansion-panel-content>
        </v-expansion-panel>

        <v-expansion-panel class="mt-5">
          <v-expansion-panel-header
            class="light-background"
            @click="headerClicked = !headerClicked"
          >
            <h5 :class="{ blueHeader: headerClicked }">Post-Service</h5>
            <template v-slot:actions>
              <v-icon color="rgba(0, 99, 167, 1)"> mdi-plus </v-icon>
            </template>
          </v-expansion-panel-header>
          <v-expansion-panel-content class="light-background">
            <PostService />
          </v-expansion-panel-content>
        </v-expansion-panel>

        <v-expansion-panel class="mt-5">
          <v-expansion-panel-header
            class="light-background"
            @click="headerClicked = !headerClicked"
          >
            <h5 :class="{ blueHeader: headerClicked }">Comments</h5>
            <template v-slot:actions>
              <v-icon color="rgba(0, 99, 167, 1)"> mdi-plus </v-icon>
            </template>
          </v-expansion-panel-header>
          <v-expansion-panel-content class="light-background">
            <Comments />
          </v-expansion-panel-content>
        </v-expansion-panel>
      </v-expansion-panels>
    </div>
    <!-- End of Service Book Section -->
  </div>
</template>

<script>
import Contacts from "./ServiceBookPanels/Contacts.vue";
import HoursOfOperation from "./ServiceBookPanels/HoursOfOperation.vue";
import PreService from "./ServiceBookPanels/PreService.vue";
import Service from "./ServiceBookPanels/Service.vue";
import PostService from "./ServiceBookPanels/PostService.vue";
import Comments from "./ServiceBookPanels/Comments.vue";

export default {
  name: "ServiceBook",
  components: {
    Contacts,
    HoursOfOperation,
    PreService,
    Service,
    PostService,
    Comments,
  },
  data() {
    return {
      numberOfBoxes: 6,
      avgNumOfPallets: 4,
      avgNumOfControls: 12,
      avgTimeSpent: 2,
      icon: "mdi-plus",
      headerClicked: false,
    };
  },
  methods: {
    changeIcon() {
      this.icon = "mdi-minus";
      this.headerClicked = true;
    },
  },
};
</script>

<style>
p {
  font-family: Arial;
  font-style: normal;
  font-style: bold;
  font-size: 15px;
  color: #111111;
}

h5 {
  text-align: left;
  font-family: Arial;
  font-style: normal;
  font-weight: bold;
  font-size: 28px;
  /* line-height: 150%; */
  color: #111111;
}

#svcBook h5,
#panels h5 {
  display: flex;
  align-items: flex-start;
  justify-content: flex-start;
}

.light-background {
  background-color: #f7f9fe;
}

.blueHeader {
  color: #0063a7 !important;
}
</style>