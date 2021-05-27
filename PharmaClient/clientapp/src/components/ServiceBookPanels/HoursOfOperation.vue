<template>
  <v-container id="hoursOfOp" class="grey lighten-5" fluid>
    <v-row v-model="item">
      <v-col v-for="item in workHoursByDay" :key="item" class="custom7cols">
        <h5>{{ item.day }}</h5>
      </v-col>
    </v-row>

    <v-row v-model="item">
      <v-col v-for="item in workHoursByDay" :key="item" class="custom7cols">
        <p>{{ item.workingHours }}</p>
      </v-col>
    </v-row>

    <br>

    <v-row>
      <v-col md="2">
        <h5>Minutes on Site:</h5> 
      </v-col>
      <v-col md="1" justify-end>
        <p>{{ this.minutesOnSite }}</p> 
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
export default {
  name: 'HoursOfOperation',
  data() {
    return {
      minutesOnSite: '180',
      workHoursByDay: [
        {
          day: 'Monday',
          workingHours: '8:00 am - 5:00 pm'
        },
        {
          day: 'Tuesday',
          workingHours: '8:00 am - 5:00 pm'
        },
        {
          day: 'Wednesday',
          workingHours: '8:00 am - 5:00 pm'
        },
        {
          day: 'Thursday',
          workingHours: '8:00 am - 5:00 pm'
        },
        {
          day: 'Friday',
          workingHours: '8:00 am - 5:00 pm'
        },
        {
          day: 'Saturday',
          workingHours: 'Closed'
        },
        {
          day: 'Sunday',
          workingHours: 'Closed'
        }
      ]
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
  width: 14%;
  max-width: 14%;
  flex-basis: 14%;
}
</style>