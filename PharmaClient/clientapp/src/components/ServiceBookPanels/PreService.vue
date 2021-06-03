<template>
  <div id="svcBookPreSvc" class="mb-6" fluid>

    <div id="editInfo">
      <EditInformation v-on:clicked="onClickEditInfo"></EditInformation>

      <!-- Pre-Service Questions and Answers -->
      <v-row v-for="(item,i) in preSvcQuestions" :key="i" :id="'answerRow'+item.number" no-gutters>
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
  import EditInformation from './Helpers/EditInformation'

  export default {
    name: 'PreService',
    components: {
        EditInformation   
    },
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
      onClickEditInfo(value) {
                this.isEditing = value
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