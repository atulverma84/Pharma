<style>
    /* div .theme--light.v-calendar-events .v-event-timed {
        border-radius: 8px;
        border-left: 8px solid blue !important;
    }*/
    .complete {
        border-left: 8px solid #0dba61 !important;
        height: 100%;
        width: 100%;
    }

    .cancelled {
        border-left: 8px solid #b30000 !important;
        height: 100%;
        width: 100%;
    }

    .confirmed {
        border-left: 8px solid #0063a7 !important;
        height: 100%;
        width: 100%;
    }

    .unconfirmed {
        border-left: 8px solid #76777a !important;
        height: 100%;
        width: 100%;
    }

    .event-header-time {
        font-size: 16px;
        margin-bottom: 5px !important;
        color: black;
    }

    .event-header-name {
        font-size: 18px;
        font-weight: bold;
        color: black;
        overflow: hidden;
        text-overflow: ellipsis;
        white-space: nowrap;
    }

    .event-header-btn {
        text-transform: none !important;
        font-size: 18px !important;
        font-weight: 700 !important;
    }

    .maxDiv {
        height: 100%;
        width: 100%;
    }
    .calenderDiv {
        height: 350px;
        width: 280px;
        border-radius: 8px;
        background-color: white;
        text-align: center;
    }

    .completeBorderColor {
        border: 1px solid #0DBA61 !important;
    }

    .cancelledBorderColor {
        border: 1px solid #B30000 !important;
    }

    .confirmedBorderColor {
        border: 1px solid #0063A7 !important;
    }

    .unconfirmedBorderColor {
        border: 1px solid #76777A !important;
    }
</style>

<template>


    <v-row class="fill-height">
        <v-col sm="9">
            <v-sheet height="64">
                <!--<v-toolbar flat>
                    <v-btn outlined class="mr-4" color="grey darken-2" @click="setToday">
                        Today
                    </v-btn>
                    <v-btn fab text small color="grey darken-2" @click="prev">
                        <v-icon small> mdi-chevron-left </v-icon>
                    </v-btn>
                    <v-btn fab text small color="grey darken-2" @click="next">
                        <v-icon small> mdi-chevron-right </v-icon>
                    </v-btn>

                    <v-toolbar-title v-if="$refs.calendar">
                        {{ $refs.calendar.title }}
                    </v-toolbar-title>
                </v-toolbar>-->
                <h1 class="pt-2 pl-5">Hello Alex!</h1>
            </v-sheet>
            <v-sheet height="600">
                <v-calendar ref="calendar"
                             hide-header
                            v-model="focus"
                            color="primary"
                            :events="events"
                            :event-color="getStatusColor"
                            :type="type"
                            first-interval="6"
                            interval-height="72"
                            @click:event="showEvent"
                            @click:more="viewDay"
                            @click:date="viewDay">
                    <template v-slot:event="{ event }">
                        <div :class="event.state">
                            <div class="pa-3" style="width:100%">
                                <div style="float: left; width:75% ;">

                                    <p class="event-header-time">
                                        {{ event.time }}
                                    </p>
                                    <div class="event-header-name mt-n1">
                                        {{ event.name }}
                                    </div>

                                </div>
                                <div style="float: right ; width:25%">
                                    <v-btn :color="getDarkStatusColor(event)"
                                           class="event-header-btn pa-0"
                                           text
                                           to="/StartService"
                                           @click.native.stop>
                                        {{getButtonText(event)}}<v-icon class="pl-1">mdi-arrow-right</v-icon>
                                    </v-btn>
                                </div>
                            </div>

                            <div v-if="event.duration >= 3" class="maxDiv">
                                <div style="font-size: 16px; white-space: normal"
                                     class="maxDiv">
                                    <v-list :color="getStatusColor(event)" class="maxDiv pa-0">
                                        <v-divider :color="getDarkStatusColor(event)"
                                                   class="mt-10"></v-divider>

                                        <v-row class="maxDiv ma-0 pl-5 pt-1">
                                            <v-col sm="4" class="maxDiv pa-0 ma-0">
                                                <v-row class="mt-0 mb-0">
                                                    <v-col sm="1" class="pa-1">
                                                        <v-icon medium :color="getDarkStatusColor(event)">mdi-file-outline</v-icon>
                                                    </v-col>
                                                    <v-col sm="11" class="pa-1">
                                                        <b>Order No.:</b>
                                                        {{ event.orderNumber }}
                                                    </v-col>
                                                </v-row>
                                                <v-row class="mt-0 mb-0">
                                                    <v-col sm="1" class="pa-1">
                                                        <v-icon medium :color="getDarkStatusColor(event)">
                                                            mdi-account
                                                        </v-icon>
                                                    </v-col>
                                                    <v-col sm="11" class="pa-1">
                                                        {{ event.customerName }}
                                                    </v-col>
                                                </v-row>
                                                <v-row class="mt-0 mb-0">
                                                    <v-col sm="1" class="pa-1">
                                                        <v-icon medium :color="getDarkStatusColor(event)">
                                                            mdi-phone
                                                        </v-icon>
                                                    </v-col>
                                                    <v-col sm="11" class="pa-1">
                                                        {{ event.phoneNumber }}
                                                    </v-col>
                                                </v-row>
                                            </v-col>
                                            <v-col sm="4" class="maxDiv pa-0 ma-0">
                                                <v-row class="mt-0 mb-1">
                                                    <v-col sm="1" class="pa-1">
                                                        <v-icon medium :color="getDarkStatusColor(event)">mdi-email</v-icon>
                                                    </v-col>
                                                    <v-col sm="11" class="pa-1">
                                                        <a :href="`mailto:${event.emailId}`">
                                                            {{ event.emailId }}
                                                        </a>
                                                    </v-col>
                                                </v-row>
                                                <v-row class="mt-0 mb-1">
                                                    <v-col sm="1" class="pa-1">
                                                        <v-icon medium :color="getDarkStatusColor(event)">
                                                            mdi-map-marker
                                                        </v-icon>
                                                    </v-col>
                                                    <v-col sm="11" class="pa-1">
                                                        {{ event.address }}
                                                    </v-col>
                                                </v-row>
                                            </v-col>
                                            <v-col sm="4" class="maxDiv pa-0 ma-0">
                                                <v-row class="mt-0 mb-1">
                                                    <v-col sm="" class="pa-1">
                                                        <b>Average No. Boxes :</b>
                                                    </v-col>
                                                    <v-col sm="4" class="pa-1">
                                                        {{ event.averageNumberofBox }}
                                                    </v-col>
                                                </v-row>
                                                <v-row class="mt-0 mb-1">
                                                    <v-col sm="8" class="pa-1">
                                                        <b>Average No. of Pallets :</b>
                                                    </v-col>
                                                    <v-col sm="4" class="pa-1">
                                                        {{ event.averageNumberofPallets }}
                                                    </v-col>
                                                </v-row>

                                                <v-row class="mt-0 mb-1">
                                                    <v-col sm="8" class="pa-1">
                                                        <b>Average No. of Controls :</b>
                                                    </v-col>
                                                    <v-col sm="4" class="pa-1">
                                                        {{ event.averageNumberofControls }}
                                                    </v-col>
                                                </v-row>
                                                <v-row class="mt-0 mb-1">
                                                    <v-col sm="8" class="pa-1">
                                                        <b>Average Time Spent :</b>
                                                    </v-col>
                                                    <v-col sm="4" class="pa-1">
                                                        <b></b>{{ event.averageTimeSpent }}
                                                    </v-col>
                                                </v-row>
                                            </v-col>
                                        </v-row>
                                    </v-list>
                                </div>
                            </div>
                        </div>
                    </template>
                </v-calendar>

                <v-menu v-model="selectedOpen"
                        :close-on-content-click="false"
                        :activator="selectedElement"
                        offset-y
                        max-width="800"
                        min-width="800">
                    <v-card :color="getStatusColor(selectedEvent)" :class="setBoderColorToCard(selectedEvent)">
                        <v-list class="pa-0" :color="getStatusColor(selectedEvent)">
                            <v-list-item>
                                <v-toolbar-title v-html="selectedEvent.name"></v-toolbar-title>
                            </v-list-item>
                        </v-list>

                        <v-divider :color="getDarkStatusColor(selectedEvent)"></v-divider>

                        <v-list>
                            <v-container class="pl-5 pr-5 pt-1 pb-1">
                                <v-row>
                                    <v-col sm="4">
                                        <v-row class="mt-0 mb-1">
                                            <v-col sm="1" class="pa-1">
                                                <v-icon small :color="getDarkStatusColor(selectedEvent)">mdi-file-outline</v-icon>
                                            </v-col>
                                            <v-col sm="11" class="pa-1">
                                                <b>Order No.:</b>
                                                {{ selectedEvent.orderNumber }}
                                            </v-col>
                                        </v-row>
                                        <v-row class="mt-0 mb-1">
                                            <v-col sm="1" class="pa-1">
                                                <v-icon small
                                                        :color="getDarkStatusColor(selectedEvent)">
                                                    mdi-account
                                                </v-icon>
                                            </v-col>
                                            <v-col sm="11" class="pa-1">
                                                {{ selectedEvent.customerName }}
                                            </v-col>
                                        </v-row>
                                        <v-row class="mt-0 mb-1">
                                            <v-col sm="1" class="pa-1">
                                                <v-icon small
                                                        :color="getDarkStatusColor(selectedEvent)">
                                                    mdi-phone
                                                </v-icon>
                                            </v-col>
                                            <v-col sm="11" class="pa-1">
                                                {{ selectedEvent.phoneNumber }}
                                            </v-col>
                                        </v-row>
                                    </v-col>
                                    <v-col sm="4">
                                        <v-row class="mt-0 mb-1">
                                            <v-col sm="1" class="pa-1">
                                                <v-icon small :color="getDarkStatusColor(selectedEvent)">mdi-email</v-icon>
                                            </v-col>
                                            <v-col sm="11" class="pa-1">
                                                <a :href="`mailto:${selectedEvent.emailId}`">
                                                    {{ selectedEvent.emailId }}
                                                </a>
                                            </v-col>
                                        </v-row>
                                        <v-row class="mt-0 mb-1">
                                            <v-col sm="1" class="pa-1">
                                                <v-icon small
                                                        :color="getDarkStatusColor(selectedEvent)">
                                                    mdi-map-marker
                                                </v-icon>
                                            </v-col>
                                            <v-col sm="11" class="pa-1">
                                                {{ selectedEvent.address }}
                                            </v-col>
                                        </v-row>
                                    </v-col>
                                    <v-col sm="4">
                                        <v-row class="mt-0 mb-1">
                                            <v-col sm="9" class="pa-1">
                                                <b>Average No. Boxes :</b>
                                            </v-col>
                                            <v-col sm="3" class="pa-1">
                                                {{ selectedEvent.averageNumberofBox }}
                                            </v-col>
                                        </v-row>
                                        <v-row class="mt-0 mb-1">
                                            <v-col sm="9" class="pa-1">
                                                <b>Average No. of Pallets :</b>
                                            </v-col>
                                            <v-col sm="3" class="pa-1">
                                                {{ selectedEvent.averageNumberofPallets }}
                                            </v-col>
                                        </v-row>

                                        <v-row class="mt-0 mb-1">
                                            <v-col sm="9" class="pa-1">
                                                <b>Average No. of Controls :</b>
                                            </v-col>
                                            <v-col sm="3" class="pa-1">
                                                {{ selectedEvent.averageNumberofControls }}
                                            </v-col>
                                        </v-row>
                                        <v-row class="mt-0 mb-1">
                                            <v-col sm="9" class="pa-1">
                                                <b>Average Time Spent :</b>
                                            </v-col>
                                            <v-col sm="3" class="pa-1">
                                                <b></b>{{ selectedEvent.averageTimeSpent }}
                                            </v-col>
                                        </v-row>
                                    </v-col>
                                </v-row>
                            </v-container>
                        </v-list>

                        <v-divider :color="getDarkStatusColor(selectedEvent)"></v-divider>

                        <v-card-actions>
                            <v-spacer></v-spacer>
                            <v-btn text
                                   color="secondary"
                                   @click="selectedOpen = false"
                                   height="25">
                                Cancel
                            </v-btn>
                        </v-card-actions>
                    </v-card>
                </v-menu>
            </v-sheet>
        </v-col>
        <v-col sm="3" style="background-color: #F7F9FE">
            <v-row >
                <div  class="mt-13 ml-3 calenderDiv">
                    <div style="font-size: 28px">Your Work Calendar:</div>
                    <v-date-picker v-model="focus" color="primary"  full-width height="240" 
                                   no-title></v-date-picker>
                </div>
            </v-row>

        </v-col>
    </v-row>
</template>

<script>
    export default {
        name: "calender",
        data: () => ({
            focus: new Date().toISOString().substr(0, 10),
            type: "day",
            typeToLabel: {
                month: "Month",
                week: "Week",
                day: "Day",
                "4day": "4 Days",
            },
            selectedEvent: {},
            selectedElement: null,
            selectedOpen: false,
            events: [
                {
                    state: "complete",
                    time: "09:00 - 12:00",
                    name: "Pharmacy B | SUNS008",
                    start: "2021-05-28 9:00:00",
                    end: "2021-05-28 12:00:00",
                    color: "yellow",
                    duration: "3",
                    orderNumber: "t6UJ9A005GXH",
                    customerName: "Chris Test",
                    phoneNumber: "1234567890",
                    emailId: "chris@test.com",
                    address: "Xyz test test",
                    averageNumberofBox: "6",
                    averageNumberofPallets: "4",
                    averageNumberofControls: "12",
                    averageTimeSpent: "3 hours",
                },
                {
                    state: "complete",
                    time: "09:00 - 12:00",
                    name: "Pharmacy B | SUNS008",
                    start: "2021-05-27 9:00:00",
                    end: "2021-05-27 12:00:00",
                    color: "yellow",
                    duration: "3",
                    orderNumber: "t6UJ9A005GXH",
                    customerName: "Chris Test",
                    phoneNumber: "1234567890",
                    emailId: "chris@test.com",
                    address: "Xyz test test",
                    averageNumberofBox: "6",
                    averageNumberofPallets: "4",
                    averageNumberofControls: "12",
                    averageTimeSpent: "3 hours",
                },
                {
                    state: "cancelled",
                    time: "07:00 - 09:00",
                    name: "Pharmacy C | Encompass",
                    start: "2021-05-28 07:00:00",
                    end: "2021-05-28 09:00:00",
                    color: "red",
                    duration: "2",
                    orderNumber: "333",
                    customerName: "Encompass Test",
                    phoneNumber: "1234567890",
                    emailId: "chris@test.com",
                    address: "Xyz test test",
                    averageNumberofBox: "6",
                    averageNumberofPallets: "4",
                    averageNumberofControls: "12",
                    averageTimeSpent: "3 hours",
                },
                {
                    state: "confirmed",
                    time: "13:00 - 16:00",
                    name:
                        "Pharmacy C | Encompass Health Rehabilitation Hospital of Richmond",
                    start: "2021-05-28 13:00:00",
                    end: "2021-05-28 16:00:00",
                    color: "green",
                    duration: "3",
                    orderNumber: "t6UJ9A005GXH",
                    customerName: "Encompass Health Rehabilitation Hospital of Richmond",
                    phoneNumber: "1234567890",
                    emailId: "Chris@test.com",
                    address: "1465 East Parkdale Avenue, Manistee, Michigan(MI) 49660",
                    averageNumberofBox: "6",
                    averageNumberofPallets: "4",
                    averageNumberofControls: "12",
                    averageTimeSpent: "3 hours",
                },
                {
                    state: "unconfirmed",
                    time: "16:00 - 24:00",
                    name:
                        "Pharmacy C | Encompass Health Rehabilitation Hospital of Richmond",
                    start: "2021-05-28 16:00:00",
                    end: "2021-05-28 24:00:00",
                    color: "green",
                    duration: "8",
                    orderNumber: "t6UJ9A005GXH",
                    customerName: "Encompass Health Rehabilitation Hospital of Richmond",
                    phoneNumber: "1234567890",
                    emailId: "Chris@test.com",
                    address: "1465 East Parkdale Avenue, Manistee, Michigan(MI) 49660",
                    averageNumberofBox: "6",
                    averageNumberofPallets: "4",
                    averageNumberofControls: "12",
                    averageTimeSpent: "3 hours",
                },
            ],
            colors: [
                "blue",
                "indigo",
                "deep-purple",
                "cyan",
                "green",
                "orange",
                "grey darken-1",
            ],
            names: [
                "<h1>Meeting</h1>",
                "Holiday",
                "PTO",
                "Travel",
                "Event",
                "Birthday",
                "Conference",
                "Party",
            ],
        }),
        mounted() {
            this.$refs.calendar.checkChange();
        },
        methods: {
            viewDay({ date }) {
                this.focus = date;
                this.type = "day";
            },
            getStatusColor(event) {
                console.log(this.focus);
                if (event.state === "complete") {
                    return "#B5FFD9";
                } else if (event.state === "cancelled") {
                    return "#F9CDD0";
                } else if (event.state === "confirmed") {
                    return "#E8F4FE";
                } else {
                    return "#EFF0F6";
                }
            },
            getButtonText(event) {
                if (event.state === "complete") {
                    return "Service Completed";
                } else if (event.state === "cancelled") {
                    return "Cancelled Service";
                } else if (event.state === "confirmed") {
                    return "Begin Inventory";
                } else {
                    return "Begin Inventory";
                }
 
            },
            getDarkStatusColor(event) {
                if (event.state === "complete") {
                    return "#0DBA61";
                } else if (event.state === "cancelled") {
                    return "#B30000";
                } else if (event.state === "confirmed") {
                    return "#0063A7";
                } else {
                    return "#76777A";
                }
            },
            setBoderColorToCard(event) {
                if (event.state === "complete") {
                    return "completeBorderColor";
                } else if (event.state === "cancelled") {
                    return "cancelledBorderColor";
                } else if (event.state === "confirmed") {
                    return "confirmedBorderColor";
                } else {
                    return "unconfirmedBorderColor";
                }
            },
            setToday() {
                this.focus = "";
            },
            prev() {
                this.$refs.calendar.prev();
            },
            next() {
                this.$refs.calendar.next();
            },
            showEvent({ nativeEvent, event }) {
                const open = () => {
                    this.selectedEvent = event;
                    this.selectedElement = nativeEvent.target;
                    requestAnimationFrame(() =>
                        requestAnimationFrame(() => (this.selectedOpen = true))
                    );
                };

                if (this.selectedOpen) {
                    this.selectedOpen = false;
                    requestAnimationFrame(() => requestAnimationFrame(() => open()));
                } else {
                    open();
                }

                nativeEvent.stopPropagation();
            },
            rnd(a, b) {
                return Math.floor((b - a + 1) * Math.random()) + a;
            },
        },
    };
</script>


