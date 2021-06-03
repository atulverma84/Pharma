<template>

  <div id="svcBookHOP" class="mb-6" fluid>

    <EditInformation v-on:clicked="onClickEditInfo"></EditInformation>
    <br>

    <!-- ReadOnly Mode Section -->
    <div v-show="!isEditing">
      <v-row v-model="item">
        <v-col v-for="item in workHoursByDay" :key="item.index" class="custom7cols">
          <h5>{{ item.day }}</h5>
        </v-col>
      </v-row>

      <v-row v-model="item" no-gutters>
        <v-col v-for="item in workHoursByDay" :key="item.id">
          <p v-for="hours in item.workingHourSlots" :key="hours">{{ hours.preLunchFrom }} - {{ hours.postLunchTo }}</p>
        </v-col>
      </v-row>
    </div>
    <!-- End of ReadOnly Mode Section -->

    <!-- Edit Mode Section -->
    <div v-show="isEditing">
      <!-- Monday Start -->
      <v-row no-gutters>
        <v-col md="1">
          <h5>{{ this.workHoursByDay[0].day }}</h5>
        </v-col>
        <v-col md="1" justify-end>
          <v-select :items="this.workingHours" v-model="this.workHoursByDay[0].workingHourSlots.preLunchFrom"
            v-show="isEditing" outlined color="primary" append-to-body></v-select>
        </v-col>

        <v-col md="1"></v-col>

        <v-col md="1">
          <h5>{{ this.text1 }}</h5>
        </v-col>
        <v-col md="1" justify-end>
          <v-select :items="this.workingHours" v-model="this.workHoursByDay[0].workingHourSlots.preLunchTo"
            v-show="isEditing" outlined color="primary" append-to-body></v-select>
        </v-col>

        <v-col md="2"></v-col>

        <v-col md="1">
          <h5>{{ this.text2 }}</h5>
        </v-col>
        <v-col md="1" justify-end>
          <v-select :items="this.workingHours" v-model="this.workHoursByDay[0].workingHourSlots.postLunchFrom"
            v-show="isEditing" outlined color="primary" append-to-body></v-select>
        </v-col>

        <v-col md="1"></v-col>

        <v-col md="1">
          <h5>{{ this.text1 }}</h5>
        </v-col>
        <v-col md="1" justify-end>
          <v-select :items="this.workingHours" v-model="this.workHoursByDay[0].workingHourSlots.postLunchTo"
            v-show="isEditing" outlined color="primary" append-to-body></v-select>
        </v-col>

      </v-row>
      <!-- Monday End -->

      <!-- TODO Work on the checkbox (find a Vuetify alternative) -->
      <v-row no-gutters>
        <v-col md="1"></v-col>
        <v-col md="4">          
          <div class="round">
            <input type="checkbox" id="checkbox" />
            <label for="checkbox"></label>
          </div>
        </v-col>
      </v-row>

      <!-- Tuesday Start -->
      <v-row>
        <v-col md="1">
          <h5>{{ this.workHoursByDay[1].day }}</h5>
        </v-col>
        <v-col md="1" justify-end>
          <v-select :items="this.workingHours" v-model="this.workHoursByDay[1].workingHourSlots.preLunchFrom"
            v-show="isEditing" outlined color="primary" append-to-body></v-select>
        </v-col>

        <v-col md="1"></v-col>

        <v-col md="1">
          <h5>{{ this.text1 }}</h5>
        </v-col>
        <v-col md="1" justify-end>
          <v-select :items="this.workingHours" v-model="this.workHoursByDay[1].workingHourSlots.preLunchTo"
            v-show="isEditing" outlined color="primary" append-to-body></v-select>
        </v-col>

        <v-col md="2"></v-col>

        <v-col md="1">
          <h5>{{ this.text2 }}</h5>
        </v-col>
        <v-col md="1" justify-end>
          <v-select :items="this.workingHours" v-model="this.workHoursByDay[1].workingHourSlots.postLunchFrom"
            v-show="isEditing" outlined color="primary" append-to-body></v-select>
        </v-col>

        <v-col md="1"></v-col>

        <v-col md="1">
          <h5>{{ this.text1 }}</h5>
        </v-col>
        <v-col md="1" justify-end>
          <v-select :items="this.workingHours" v-model="this.workHoursByDay[1].workingHourSlots.postLunchTo"
            v-show="isEditing" outlined color="primary" append-to-body></v-select>
        </v-col>

      </v-row>
      <!-- Tuesday End -->

      <!-- Wednesday Start -->
      <v-row no-gutters>
        <v-col md="1">
          <h5>{{ this.workHoursByDay[2].day }}</h5>
        </v-col>
        <v-col md="1" justify-end>
          <v-select :items="this.workingHours" v-model="this.workHoursByDay[2].workingHourSlots.preLunchFrom"
            v-show="isEditing" outlined color="primary" append-to-body></v-select>
        </v-col>

        <v-col md="1"></v-col>

        <v-col md="1">
          <h5>{{ this.text1 }}</h5>
        </v-col>
        <v-col md="1" justify-end>
          <v-select :items="this.workingHours" v-model="this.workHoursByDay[2].workingHourSlots.preLunchTo"
            v-show="isEditing" outlined color="primary" append-to-body></v-select>
        </v-col>

        <v-col md="2"></v-col>

        <v-col md="1">
          <h5>{{ this.text2 }}</h5>
        </v-col>
        <v-col md="1" justify-end>
          <v-select :items="this.workingHours" v-model="this.workHoursByDay[2].workingHourSlots.postLunchFrom"
            v-show="isEditing" outlined color="primary" append-to-body></v-select>
        </v-col>

        <v-col md="1"></v-col>

        <v-col md="1">
          <h5>{{ this.text1 }}</h5>
        </v-col>
        <v-col md="1" justify-end>
          <v-select :items="this.workingHours" v-model="this.workHoursByDay[2].workingHourSlots.postLunchTo"
            v-show="isEditing" outlined color="primary" append-to-body></v-select>
        </v-col>

      </v-row>
      <!-- Wednesday End -->

      <!-- Thursday Start -->
      <v-row no-gutters>
        <v-col md="1">
          <h5>{{ this.workHoursByDay[3].day }}</h5>
        </v-col>
        <v-col md="1" justify-end>
          <v-select :items="this.workingHours" v-model="this.workHoursByDay[3].workingHourSlots.preLunchFrom"
            v-show="isEditing" outlined color="primary" append-to-body></v-select>
        </v-col>

        <v-col md="1"></v-col>

        <v-col md="1">
          <h5>{{ this.text1 }}</h5>
        </v-col>
        <v-col md="1" justify-end>
          <v-select :items="this.workingHours" v-model="this.workHoursByDay[3].workingHourSlots.preLunchTo"
            v-show="isEditing" outlined color="primary" append-to-body></v-select>
        </v-col>

        <v-col md="2"></v-col>

        <v-col md="1">
          <h5>{{ this.text2 }}</h5>
        </v-col>
        <v-col md="1" justify-end>
          <v-select :items="this.workingHours" v-model="this.workHoursByDay[3].workingHourSlots.postLunchFrom"
            v-show="isEditing" outlined color="primary" append-to-body></v-select>
        </v-col>

        <v-col md="1"></v-col>

        <v-col md="1">
          <h5>{{ this.text1 }}</h5>
        </v-col>
        <v-col md="1" justify-end>
          <v-select :items="this.workingHours" v-model="this.workHoursByDay[1].workingHourSlots.postLunchTo"
            v-show="isEditing" outlined color="primary" append-to-body></v-select>
        </v-col>

      </v-row>
      <!-- Thursday End -->

      <!-- Friday Start -->
      <v-row no-gutters>
        <v-col md="1">
          <h5>{{ this.workHoursByDay[4].day }}</h5>
        </v-col>
        <v-col md="1" justify-end>
          <v-select :items="this.workingHours" v-model="this.workHoursByDay[4].workingHourSlots.preLunchFrom"
            v-show="isEditing" outlined color="primary" append-to-body></v-select>
        </v-col>

        <v-col md="1"></v-col>

        <v-col md="1">
          <h5>{{ this.text1 }}</h5>
        </v-col>
        <v-col md="1" justify-end>
          <v-select :items="this.workingHours" v-model="this.workHoursByDay[4].workingHourSlots.preLunchTo"
            v-show="isEditing" outlined color="primary" append-to-body></v-select>
        </v-col>

        <v-col md="2"></v-col>

        <v-col md="1">
          <h5>{{ this.text2 }}</h5>
        </v-col>
        <v-col md="1" justify-end>
          <v-select :items="this.workingHours" v-model="this.workHoursByDay[4].workingHourSlots.postLunchFrom"
            v-show="isEditing" outlined color="primary" append-to-body></v-select>
        </v-col>

        <v-col md="1"></v-col>

        <v-col md="1">
          <h5>{{ this.text1 }}</h5>
        </v-col>
        <v-col md="1" justify-end>
          <v-select :items="this.workingHours" v-model="this.workHoursByDay[4].workingHourSlots.postLunchTo"
            v-show="isEditing" outlined color="primary" append-to-body></v-select>
        </v-col>

      </v-row>
      <!-- Friday End -->

    </div>
    <!-- End of Edit Mode Section -->

    <br>

    <v-row>
      <v-col md="2">
        <h5>Minutes on Site:</h5>
      </v-col>
      <v-col md="2" justify-end>
        <p v-show="!isEditing">{{ this.minutesOnSite }}</p>
        <v-text-field v-model="this.minutesOnSite" clearable outlined v-show="isEditing" color="primary" required>
          {{ this.minutesOnSite }}</v-text-field>
      </v-col>
    </v-row>

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

</template>

<script>
  import EditInformation from './Helpers/EditInformation'

  export default {
    name: 'HoursOfOperation',
    components: {
      EditInformation
    },
    data() {
      return {
        isEditing: false,
        text1: 'To',
        text2: 'Also From',
        minutesOnSite: '180',
        workingHours: ['8:00 am', '9:00 am', '10:00 am', '11:00 am', '12:00 pm', '1:00 pm', '2:00 pm', '3:00 pm',
          '4:00 pm', '5:00 pm'
        ],
        workHoursByDay: [{
            index: 1,
            day: 'Monday',
            workingHourSlots: [{
              id: 1,
              preLunchFrom: '8:00 am',
              preLunchTo: '5:00 pm',
              postLunchFrom: '8:00 am',
              postLunchTo: '5:00 pm'
            }]
          },
          {
            index: 2,
            day: 'Tuesday',
            workingHourSlots: [{
              id: 2,
              preLunchFrom: '8:00 am',
              preLunchTo: '5:00 pm',
              postLunchFrom: '8:00 am',
              postLunchTo: '5:00 pm'
            }]
          },
          {
            index: 3,
            day: 'Wednesday',
            workingHourSlots: [{
              id: 3,
              preLunchFrom: '8:00 am',
              preLunchTo: '5:00 pm',
              postLunchFrom: '8:00 am',
              postLunchTo: '5:00 pm'
            }]
          },
          {
            index: 4,
            day: 'Thursday',
            workingHourSlots: [{
              id: 4,
              preLunchFrom: '8:00 am',
              preLunchTo: '5:00 pm',
              postLunchFrom: '8:00 am',
              postLunchTo: '5:00 pm'
            }]
          },
          {
            index: 5,
            day: 'Friday',
            workingHourSlots: [{
              id: 5,
              preLunchFrom: '8:00 am',
              preLunchTo: '5:00 pm',
              postLunchFrom: '8:00 am',
              postLunchTo: '5:00 pm'
            }]
          }
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
  p {
    font-family: Arial;
    font-style: normal;
    font-weight: normal;
    font-size: 20px;
    line-height: 160%;
  }

  .custom7cols {
    width: 20%;
    max-width: 20%;
    flex-basis: 20%;
  }

  .round {
  position: relative;
}

.round label {
  background-color: #fff;
  border: 1px solid #ccc;
  border-radius: 50%;
  cursor: pointer;
  height: 28px;
  left: 0;
  position: absolute;
  top: 0;
  width: 28px;
}

.round label:after {
  border: 2px solid #fff;
  border-top: none;
  border-right: none;
  content: "";
  height: 6px;
  left: 7px;
  opacity: 0;
  position: absolute;
  top: 8px;
  transform: rotate(-45deg);
  width: 12px;
}

.round input[type="checkbox"] {
  visibility: hidden;
}

.round input[type="checkbox"]:checked + label {
  background-color: #0063A7;
  border-color: #0063A7;
}

.round input[type="checkbox"]:checked + label:after {
  opacity: 1;
}
</style>