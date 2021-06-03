<template>
  <div id="svcBookPostSvc" class="mb-6" fluid>

    <div id="editInfo">
      <EditInformation v-on:clicked="onClickEditInfo"></EditInformation>

      <!-- Service Questions and Answers -->
      <v-row v-for="(item,i) in postSvcQuestions" :key="i" :id="'answerRow'+item.number" no-gutters>
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

  </div>
</template>

<script>
  import EditInformation from './Helpers/EditInformation'

  export default {
    name: 'Post-Service',
    components: {
        EditInformation   
    },
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
    font-size: 20px !important;
    line-height: 160%;
  }
</style>