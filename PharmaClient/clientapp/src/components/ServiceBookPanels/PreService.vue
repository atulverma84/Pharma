<template>
 <v-container id="preSvc" class="grey lighten-5 mb-6" fluid>

        <div id="editInfo">
            <!-- Edit Information Button and Dialog -->
            <v-row row-height="50" justify="end">
                <v-spacer /><v-spacer /><v-spacer /><v-spacer /><v-spacer /><v-spacer /><v-spacer /><v-spacer />

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
                                <v-container>
                                    <v-row>
                                        <p>Scheduling Contact:</p>
                                        <v-col cols="12" sm="6" md="4">
                                            <v-text-field label="First name*" required></v-text-field>
                                        </v-col>
                                        <v-col cols="12" sm="6" md="4">
                                            <v-text-field label="Last name*" hint="example of persistent helper text"
                                                persistent-hint required></v-text-field>
                                        </v-col>
                                        <v-col cols="12">
                                            <v-text-field label="Phone*" required></v-text-field>
                                        </v-col>
                                        <v-col cols="12">
                                            <v-text-field label="Email*" required></v-text-field>
                                        </v-col>
                                    </v-row>
                                    <v-spacer></v-spacer>

                                    <v-row>
                                        <h5>Service Contacts:</h5>
                                        <v-col cols="12" sm="6" md="4">
                                            <v-text-field label="First name*" required></v-text-field>
                                        </v-col>
                                        <v-col cols="12" sm="6" md="4">
                                            <v-text-field label="Last name*" hint="example of persistent helper text"
                                                persistent-hint required></v-text-field>
                                        </v-col>
                                        <v-col cols="12">
                                            <v-text-field label="Phone*" required></v-text-field>
                                        </v-col>
                                        <v-col cols="12">
                                            <v-text-field label="Email*" required></v-text-field>
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
      preSvcQuestions: [
        {
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