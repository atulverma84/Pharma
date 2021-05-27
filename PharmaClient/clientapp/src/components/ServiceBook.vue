<template>
  <div>

    <v-container id="svcBook" class="grey lighten-5">
      <h5>General Stats:</h5>

      <v-row no-gutters>
        <v-col>
          <!-- General Stats Container -->
          <v-container>
            <!-- Stats #1 - Average number of boxes -->
            <v-row max-height="40px" justify="space-around">
              <v-col md="1">
                <v-avatar color="#B7DEFF">
                  <v-icon color="rgba(0, 99, 167, 1)">mdi-package-variant-closed</v-icon>
                </v-avatar>
              </v-col>
              <v-col>
                <p class="boldHeading">{{ this.numberOfBoxes }}</p>
                <p>Average No. of Boxes</p>
              </v-col>
              <!-- End of Stats #1 - Average number of boxes -->

              <!-- Stats #2 - Average number of pallets -->
              <v-col md="1">
                <v-avatar color="#B7DEFF">
                  <v-icon color="rgba(0, 99, 167, 1)">mdi-package-variant</v-icon>
                </v-avatar>
              </v-col>
              <v-col>
                <p class="boldHeading">{{ this.avgNumOfPallets }}</p>
                <p>Average No. of Pallets</p>
              </v-col>
              <!-- End of Stats #2 - Average number of pallets -->

              <!-- Stats #3 - Average number of controls -->
              <v-col md="1">
                <v-avatar color="#B7DEFF">
                  <v-icon color="rgba(0, 99, 167, 1)">mdi-file</v-icon>
                </v-avatar>
              </v-col>
              <v-col>
                <p class="boldHeading">{{ this.avgNumOfControls }}</p>
                <p>Average No. of Controls</p>
              </v-col>
              <!-- End of Stats #3 - Average number of controls -->

              <!-- Stats #4 - Average time spent -->
              <v-col md="1">
                <v-avatar color="#B7DEFF">
                  <v-icon color="rgba(0, 99, 167, 1)">mdi-clock</v-icon>
                </v-avatar>
              </v-col>
              <v-col>
                <p class="boldHeading">{{ this.avgTimeSpent }}</p>
                <p>Average Time Spent</p>
              </v-col>
              <!-- End of Stats #4 - Average time spent -->
            </v-row>
          </v-container>
          <!-- End of General Stats Container -->
        </v-col>
      </v-row>
    </v-container>
    <v-spacer></v-spacer>

    <v-container id="panels" class="grey lighten-5">
      <!-- Service Book Section -->
      <v-expansion-panels>

        <v-expansion-panel>
          <v-expansion-panel-header>
            <h5>Contacts</h5>
            <template v-slot:actions>
              <v-icon color="rgba(0, 99, 167, 1)">
                mdi-plus
              </v-icon>
            </template>
          </v-expansion-panel-header>
          <v-expansion-panel-content>
            <Contacts />
          </v-expansion-panel-content>
        </v-expansion-panel>

        <v-expansion-panel>
          <v-expansion-panel-header>
            <h5>Hours of Operation</h5>
            <template v-slot:actions>
              <v-icon color="rgba(0, 99, 167, 1)">
                mdi-plus
              </v-icon>
            </template>
          </v-expansion-panel-header>
          <v-expansion-panel-content>
            <HoursOfOperation />
          </v-expansion-panel-content>
        </v-expansion-panel>

        <v-expansion-panel>
          <v-expansion-panel-header>
            <h5>Pre-Service</h5>
            <template v-slot:actions>
              <v-icon color="rgba(0, 99, 167, 1)">
                mdi-plus
              </v-icon>
            </template>
          </v-expansion-panel-header>
          <v-expansion-panel-content>
            <PreService />
          </v-expansion-panel-content>
        </v-expansion-panel>

        <v-expansion-panel>
          <v-expansion-panel-header>
            <h5>Service</h5>
            <template v-slot:actions>
              <v-icon color="rgba(0, 99, 167, 1)">
                mdi-plus
              </v-icon>
            </template>
          </v-expansion-panel-header>
          <v-expansion-panel-content>
            <Service />
          </v-expansion-panel-content>
        </v-expansion-panel>

      <v-expansion-panel>
        <v-expansion-panel-header>
            <h5>Post-Service</h5>
            <template v-slot:actions>
              <v-icon color="rgba(0, 99, 167, 1)">
                mdi-plus
              </v-icon>
            </template>
          </v-expansion-panel-header>
        <v-expansion-panel-content>
          <PostService />
        </v-expansion-panel-content>
      </v-expansion-panel>

      <v-expansion-panel>
        <v-expansion-panel-header>
            <h5>Misc</h5>
            <template v-slot:actions>
              <v-icon color="rgba(0, 99, 167, 1)">
                mdi-plus
              </v-icon>
            </template>
          </v-expansion-panel-header>
        <v-expansion-panel-content>
          <Misc />
        </v-expansion-panel-content>
      </v-expansion-panel>

      <v-expansion-panel>
        <v-expansion-panel-header>
            <h5>Comments</h5>
            <template v-slot:actions>
              <v-icon color="rgba(0, 99, 167, 1)">
                mdi-plus
              </v-icon>
            </template>
          </v-expansion-panel-header>
        <v-expansion-panel-content>
          <Comments />
        </v-expansion-panel-content>
      </v-expansion-panel>

      </v-expansion-panels>
    </v-container>
    <!-- End of Service Book Section -->
  </div>
</template>

<script>
  import Contacts from './ServiceBookPanels/Contacts.vue'
  import HoursOfOperation from './ServiceBookPanels/HoursOfOperation.vue'
  import PreService from './ServiceBookPanels/PreService.vue'
  import Service from './ServiceBookPanels/Service.vue'
  import PostService from './ServiceBookPanels/PostService.vue'
  import Misc from './ServiceBookPanels/Misc.vue'
  import Comments from './ServiceBookPanels/Comments.vue'

  export default {
    name: "ServiceBook",
    components: {
      Contacts,
      HoursOfOperation,
      PreService,
      Service,
      PostService,
      Misc,
      Comments
    },
    data() {
      return {
        numberOfBoxes: 6,
        avgNumOfPallets: 4,
        avgNumOfControls: 12,
        avgTimeSpent: 2
      }
    },
    methods: {
      changeIcon() {
        this.icon = 'mdi-minus'
      }
    }
  }
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
</style>