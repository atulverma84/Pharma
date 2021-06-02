<template>
  <div id="svcBookPreSvc" class="mb-6" fluid>

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

      <!-- Pre-Service Questions and Answers -->
      <v-row v-for="(item,i) in preSvcQuestions" :key="i" :id="'answerRow'+item.number">
        <v-col md="6">
          <h4>{{ item.number }}. {{ item.question }}</h4>
        </v-col>

        <v-col md="6">
          <p v-show="!isEditing">{{ item.answer }}</p>
          <v-text-field v-model="item.answer" v-show="isEditing" clearable outlined color="primary" required>{{ item.answer }}</v-text-field>
        </v-col>
      </v-row>
      <!-- End of Pre-Service Questions and Answers -->

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
    name: 'PreService',
    data() {
      return {
        dialog: false,
        isEditing: false,
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
    font-size: 20px;
    line-height: 160%;
  }
</style>