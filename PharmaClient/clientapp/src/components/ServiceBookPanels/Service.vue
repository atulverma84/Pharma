<template>
  <div id="svcBookSvc" class="mb-6" fluid>

    <div id="editInfo">
      <!-- Edit Information Button and Dialog -->
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
      <!-- End of Edit Information Button and Dialog -->

      <!-- Service Questions and Answers -->
      <v-row v-for="(item,i) in svcQuestions" :key="i" :id="'answerRow'+item.number">
        <v-col md="6">
          <h4>{{ item.number }}. {{ item.question }}</h4>
        </v-col>

        <v-col md="6">
          <p v-show="!isEditing">{{ item.answer }}</p>
          <v-text-field :id="'txtAns'+item.number" v-model="item.answer" v-show="isEditing" v-if="item.number === 1" clearable outlined
            color="primary" required>{{ item.answer }}</v-text-field>
          <v-select :items="genericOptions" :id="'selectAns'+item.number" v-model="item.answer" v-show="isEditing" v-if="item.number !== 1 && item.number !== 3" outlined color="primary"></v-select>
          <v-select :items="controlOptions" :id="'selectAns'+item.number" v-model="item.answer" v-show="isEditing" v-if="item.number === 3" outlined color="primary"></v-select>
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

  </div>
</template>

<script>
  export default {
    name: 'Service',
    data() {
      return {
        dialog: false,
        isEditing: false,
        svcQuestions: [{
            number: 1,
            question: 'Are there any specific customer considerations, concerns, or expectations to be aware of',
            answer: 'Complete control of their drugs on exact time of the service.'
          },
          {
            number: 2,
            question: 'Does the customer do a good job of separating/sorting controls?',
            answer: 'Yes'
          },
          {
            number: 3,
            question: 'Should the rep start with non-controls or controls?',
            answer: 'Non-Controls'
          },
          {
            number: 4,
            question: 'Does the POC like to review inventory list before rep prints 222 forms?',
            answer: 'No'
          },
          {
            number: 5,
            question: 'Does the customer provide an internal destruction list to compare quantities?',
            answer: 'No'
          }
        ],
        genericOptions: [
          'Yes',
          'No',
          'N/A'
        ],
        controlOptions: [
          'Controls',
          'Non-Controls'
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