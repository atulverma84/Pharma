<template>
  <v-container id="preSvc" class="grey lighten-5 mb-6" fluid>

    <div id="editInfo">
      <!-- Edit Information Button and Dialog -->
      <v-row row-height="50" justify="end">
        <v-spacer />
        <v-spacer />
        <v-spacer />
        <v-spacer />
        <v-spacer />
        <v-spacer />
        <v-spacer />
        <v-spacer />

        <v-col>
          <v-dialog v-model="dialog" max-width="600px">
            <template v-slot:activator="{ on, attrs }">
              <div id="editButton">
                <span class="d-flex justify-end mb-6">
                  <v-btn color="primary" dark v-bind="attrs" v-on="on" icon>
                    <v-icon left fab>
                      mdi-square-edit-outline
                    </v-icon>
                    Edit Information
                  </v-btn>
                </span>
              </div>
            </template>
            <v-card>
              <v-card-title>
                <span class="headline">Pre-Service</span>
              </v-card-title>
              <v-card-text>
                <v-container fluid>
                  <v-row>
                    <v-col cols="4">
                      <v-subheader>{{ preSvcQuestions[0].question }}</v-subheader>
                    </v-col>
                    <v-col cols="8">
                      <v-select v-model="select" :items="items" :rules="[v => !!v || 'Item is required']" label="--Select--"
                        required></v-select>                      
                    </v-col>
                  </v-row>

                  <v-row>
                    <v-col cols="4">
                      <v-subheader>{{ preSvcQuestions[1].question }}</v-subheader>
                    </v-col>
                    <v-col cols="8">
                      <v-text-field label="Enter the instructions"></v-text-field>
                    </v-col>
                  </v-row>

                  <v-row>
                    <v-col cols="4">
                      <v-subheader>{{ preSvcQuestions[2].question }}</v-subheader>
                    </v-col>
                    <v-col cols="8">
                      <v-text-field label="Enter an address"></v-text-field>
                    </v-col>
                  </v-row>

                </v-container>

                <small>*indicates required field</small>
              </v-card-text>
              <v-card-actions>
                <v-spacer></v-spacer>
                <v-btn color="blue darken-1" text @click="dialog = false">
                  Close
                </v-btn>
                <v-btn color="blue darken-1" text @click="dialog = false">
                  Save
                </v-btn>
              </v-card-actions>
            </v-card>
          </v-dialog>
        </v-col>
      </v-row>
      <!-- End of Edit Information Button and Dialog -->

      <!-- Pre-Service Questions and Answers -->
      <v-row v-for="item in preSvcQuestions" :key="item">
        <v-col md="6">
          <h4>{{ item.number }}. {{ item.question }}</h4>
        </v-col>

        <v-col md="6">
          <p>{{ item.answer }}</p>
        </v-col>
      </v-row>
      <!-- End of Pre-Service Questions and Answers -->
    </div>

  </v-container>
</template>

<script>
  export default {
    name: 'PreService',
    data() {
      return {
        dialog: false,
        preSvcQuestions: [{
            number: 1,
            question: 'Credentials needed to gain access?',
            answer: 'Pass and Drivers License.'
          },
          {
            number: 2,
            question: 'Where to park?',
            answer: 'The Building has an internal parking. The pharmacy validates the parking.'
          },
          {
            number: 3,
            question: 'Where is pharmacy located?',
            answer: '2706 W Flourney St. Suite 500, Chicago, Illinois(IL), 60612'
          }
        ],
        items: [
          'Pass and Drivers License',
          'Failed',
          'Not Required'
        ]
      }
    }
  }
</script>

<style>
  h4 {
    font-family: Arial;
    font-style: normal;
    font-weight: bold;
    font-size: 20px;
    line-height: 160%;
  }

  p {
    font-family: Arial;
    font-style: normal;
    font-size: 20px;
    line-height: 160%;
  }
</style>