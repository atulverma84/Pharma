<template>
  <v-container id="postSvc" class="grey lighten-5 mb-6" fluid>

    <div id="editInfo">
      <!-- Edit Information Button -->
      <v-row row-height="50" justify="end">
        <v-col md="1" class="text-right">
          <div id="editButton">
            <span class="d-flex justify-end mb-4">
              <v-btn color="primary" dark @click="EditInfo" icon>
                <v-icon left fab>
                  mdi-square-edit-outline
                </v-icon>
                Edit Information
              </v-btn>
            </span>
          </div>
        </v-col>
      </v-row>
      <!-- End of Edit Information Button -->

      <!-- Service Questions and Answers -->
      <v-row v-for="(item,i) in postSvcQuestions" :key="i" :id="'answerRow'+item.number">
        <v-col md="6">
          <h4>{{ item.number }}. {{ item.question }}</h4>
        </v-col>

        <v-col md="6">
          <p v-show="!isEditing">{{ item.answer }}</p>
          <v-select :items="options" :id="'selectAns'+item.number" v-model="item.answer" v-show="isEditing" outlined color="primary" append-to-body></v-select>
        </v-col>
      </v-row>
      <!-- End of Service Questions and Answers -->

      <!-- Buttons -->
      <v-row>
        <v-col class="text-right" v-show="isEditing">
          <v-btn id="btnCancel" class="mx-2" @click="Cancel" outlined color="primary">
            Cancel
          </v-btn>
          <v-btn id="btnSave" class="mx-2" @click="SaveChanges" color="primary">
            Save Changes
          </v-btn>
        </v-col>
      </v-row>
      <!-- End of Buttons -->
    </div>

  </v-container>
</template>

<script>
  export default {
    name: 'Post-Service',
    data() {
      return {
        dialog: false,
        isEditing: false,
        postSvcQuestions: [{
            number: 1,
            question: 'Does the customer take care of UPS shipments or does the rep need to schedule it?',
            answer: 'Rep needs to schedule it.'
          }
        ],
        options: [
          'Customer takes care of UPS',
          'Rep needs to schedule it.'
        ]
      }
    },
    methods: {
      EditInfo() {
        this.isEditing = true
        console.log("Edit Button clicked.")
      },
      Cancel() {
        this.isEditing = false
      },
      SaveChanges() {
        //For closing the edit mode - Temporarily
        //Needs logic to save the new data
        this.isEditing = false
        console.log('Changes saved!')
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
    font-size: 20px !important;
    line-height: 160%;
  }
</style>