<template>
  <v-container id="preSvc" class="grey lighten-5 mb-6" fluid>

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

      <!-- Comments Section -->
      <v-row>
        <v-col md="6">
          <h4>Additional Comments</h4>
        </v-col>        
      </v-row>

      <v-row :id="addtnlComments">
        <v-col md="2">
          <p>05/17/2021</p>
        </v-col>
        <v-vol md="10">
          <h5 v-show="!this.isEditing">Lorem ipsum dolor, sit amet consectetur adipisicing elit. Facere, adipisci.</h5>
          <v-text-field :id="addtnlComment1" v-show="this.isEditing" clearable outlined
            color="primary" required></v-text-field>
        </v-vol>
      </v-row>
      <!-- End of Comments Section -->

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
    name: 'Comments',
    data() {
      return {
        dialog: false,
        isEditing: false,
        additionalComments: []
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

h5 {
    font-family: Arial;
    font-style: normal;
    font-weight: bold;
    font-size: 18px;
    line-height: 160%;
  }

  p {
    font-family: Arial;
    font-style: normal;
    font-size: 20px;
    line-height: 160%;
  }
</style>