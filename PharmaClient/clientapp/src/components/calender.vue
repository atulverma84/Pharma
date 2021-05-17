<template>
    <v-row class="fill-height">
        <v-col>
            <v-sheet height="64">
                <v-toolbar flat>
                    <v-btn outlined
                           class="mr-4"
                           color="grey darken-2"
                           @click="setToday">
                        Today
                    </v-btn>
                    <v-btn fab
                           text
                           small
                           color="grey darken-2"
                           @click="prev">
                        <v-icon small>
                            mdi-chevron-left
                        </v-icon>
                    </v-btn>
                    <v-btn fab
                           text
                           small
                           color="grey darken-2"
                           @click="next">
                        <v-icon small>
                            mdi-chevron-right
                        </v-icon>
                    </v-btn>
                    <v-toolbar-title v-if="$refs.calendar">
                        {{ $refs.calendar.title }}
                    </v-toolbar-title>
                    <v-spacer></v-spacer>
                    <v-menu bottom
                            right>
                        <template v-slot:activator="{ on, attrs }">
                            <v-btn outlined
                                   color="grey darken-2"
                                   v-bind="attrs"
                                   v-on="on">
                                <span>{{ typeToLabel[type] }} </span>
                                <v-icon right>
                                    mdi-menu-down
                                </v-icon>
                            </v-btn>
                        </template>
                        <v-list>
                            <v-list-item @click="type = 'day'">
                                <v-list-item-title>Day</v-list-item-title>
                            </v-list-item>
                            <v-list-item @click="type = 'week'">
                                <v-list-item-title>Week</v-list-item-title>
                            </v-list-item>
                            <v-list-item @click="type = 'month'">
                                <v-list-item-title>Month</v-list-item-title>
                            </v-list-item>
                            <v-list-item @click="type = '4day'">
                                <v-list-item-title>4 days</v-list-item-title>
                            </v-list-item>
                        </v-list>
                    </v-menu>
                </v-toolbar>
            </v-sheet>
            <v-sheet height="600">
                <v-calendar ref="calendar"
                            v-model="focus"
                            color="primary"
                            :events="events"
                            :event-color="getEventColor"
                            :type="type"
                            @click:event="showEvent"
                            @click:more="viewDay"
                            @click:date="viewDay"
                            @change="updateRange">
                    <template v-slot:event="{event}">
                        <v-row class="text-left">
                            <v-col class="mb-0" cols="9">
                                <div :style="{color:'black'}" class="fill-height pl-2">
                                    <p style="font-family: Arial; font-style: normal; font-weight: bold; font-size: 16px; line-height: 100%; display: flex; align-items: center; letter-spacing: 1px;"> {{ event.name }} </p>
                                   

                                </div>
                            </v-col>
                            <v-col class="mb-0 text-right">
                                <v-btn depressed style="vertical-align:top" to="/StartService" @click.native.stop>
                                    Start Service
                                    <v-icon dark
                                            right>
                                        mdi-arrow-right
                                    </v-icon>
                                </v-btn>
                            </v-col>
                        </v-row>

                          

                    </template>

                </v-calendar>
                <v-menu v-model="selectedOpen"
                        :close-on-content-click="false"
                        :activator="selectedElement"
                        offset-x>
                    <v-card color="grey lighten-4"
                            min-width="350px"
                            flat>
                        <v-toolbar :color="selectedEvent.color"
                                   dark>
                           
                            <v-toolbar-title v-html="selectedEvent.name"></v-toolbar-title>
                            <v-spacer></v-spacer>                           
                        </v-toolbar>
                        <v-card-text>
                            <span v-html="selectedEvent.details"></span>
                        </v-card-text>
                        <v-card-actions>
                            <v-btn text
                                   color="secondary"
                                   @click="selectedOpen = false">
                                Cancel
                            </v-btn>
                        </v-card-actions>
                    </v-card>
                </v-menu>
            </v-sheet>
        </v-col>
    </v-row>
</template>

<script>
    export default {
        name:"calender",
        data: () => ({
            focus: '',
            type: 'month',
            typeToLabel: {
                month: 'Month',
                week: 'Week',
                day: 'Day',
                '4day': '4 Days',
            },
            selectedEvent: {},
            selectedElement: null,
            selectedOpen: false,
            events:
                [
                    {
                        time:"10:00 - 11:30",
                        name: 'Pharmacy B | SUNS008',
                        start: '2021-05-13 10:00:00',
                        end: '2021-05-13 11:30:00',
                        color: 'cyan',
                    },
                    {
                        name: 'test',
                        start: '2021-05-14 07:00:00',
                        end: '2021-05-14 07:25:00',
                        color: 'green',
                    },
                    {
                        name: 'test',
                        start: '2021-05-16 08:00:00',
                        end: '2021-05-16 08:15:00',
                        color: 'red',
                    },
                ],
            colors: ['blue', 'indigo', 'deep-purple', 'cyan', 'green', 'orange', 'grey darken-1'],
            names: ['<h1>Meeting</h1>', 'Holiday', 'PTO', 'Travel', 'Event', 'Birthday', 'Conference', 'Party'],
        }),
        mounted() {
            this.$refs.calendar.checkChange()
        },
        methods: {
            viewDay({ date }) {
                this.focus = date
                this.type = 'day'
            },
            getEventColor(event) {
                return event.color
            },
            setToday() {
                this.focus = ''
            },
            prev() {
                this.$refs.calendar.prev()
            },
            next() {
                this.$refs.calendar.next()
            },
            showEvent({ nativeEvent, event }) {
                const open = () => {
                    this.selectedEvent = event
                    this.selectedElement = nativeEvent.target
                    requestAnimationFrame(() => requestAnimationFrame(() => this.selectedOpen = true))
                }

                if (this.selectedOpen) {
                    this.selectedOpen = false
                    requestAnimationFrame(() => requestAnimationFrame(() => open()))
                } else {
                    open()
                }

                nativeEvent.stopPropagation()
            },
            /*updateRange({ *//*start, end*//* }) {*/
            updateRange() {
                //const events = []

                //const min = new Date(`${start.date}T00:00:00`)
                //const max = new Date(`${end.date}T23:59:59`)
                //const days = (max.getTime() - min.getTime()) / 86400000
                //const eventCount = days;

                //for (let i = 0; i < eventCount; i++) {
                //    const allDay = this.rnd(0, 3) === 0
                //    const firstTimestamp = this.rnd(min.getTime(), max.getTime())
                //const first = new Date("Thu May 13 2021 14:15:00 GMT+0530")
                //    const secondTimestamp = this.rnd(2, allDay ? 288 : 8) * 900000
                //const second = new Date("Thu May 13 2021 15:45:00 GMT+0530")

                //    events.push({
                //        name: this.names[this.rnd(0, this.names.length - 1)],
                //        start: first,
                //        end: second,
                //        color: this.colors[this.rnd(0, this.colors.length - 1)],
                //        timed: !allDay,
                //    })
                //}
                //const allDay = false;
                //const firstTimestamp = this.rnd(min.getTime(), max.getTime())
              //  const first = first
                //const secondTimestamp = this.rnd(2, allDay ? 288 : 8) * 900000
               // const second = second

                //events.push({
                //    name: this.names[0],
                //    start: first,
                //    end: second,
                //    color: this.colors[0],
                //    timed: !allDay,
                //})

                //this.events = events
            },
            rnd(a, b) {
                return Math.floor((b - a + 1) * Math.random()) + a
            },
        },
    }
</script>

<!--<template>
    <v-container>
        <v-row class="text-center">
            <v-col col="12">
                <v-sheet height="500">
                    <v-calendar :now="today" :value="today" color="primary">
                        <template v-slot:day="{ present, past, date }">
                            <v-row class="fill-height">
                                <template v-if="past && tracked[date]">
                                    <v-sheet v-for="(percent, i) in tracked[date]"
                                             :key="i"
                                             :title="category[i]"
                                             :color="colors[i]"
                                             :width="`${percent}%`"
                                             height="100%"
                                             tile></v-sheet>
                                </template>
                            </v-row>
                        </template>
                    </v-calendar>
                </v-sheet>
            </v-col>
        </v-row>
    </v-container>
</template>
<script>
    export default {
        name: "calender",
        data: () => ({
            today: "2020-01-10",
            tracked: {
                "2020-01-09": [23, 45, 10],
                "2020-01-08": [10],
                "2020-01-07": [0, 78, 5],
                "2020-01-06": [0, 0, 50],
                "2020-01-05": [0, 10, 23],
                "2020-01-04": [2, 90],
                "2020-01-03": [10, 32],
                "2020-01-02": [80, 10, 10],
                "2020-01-01": [20, 25, 10],
            },
            colors: ["red", "green", "blue"],
            category: ["Development", "Meetings", "Slacking"],
        }),
    };
</script>-->
