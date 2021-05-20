<template>
    <v-container>
        <!-- Back Button -->
        <router-link to="/calender" tag="v-btn">
            <v-btn class="btnReturn" outlined x-small fab color="indigo">
                <v-icon dark>
                    mdi-arrow-left
                </v-icon>
                <h5>{{ this.jobTitle }}</h5>
            </v-btn>
        </router-link>
        <!-- End of Back Button -->
        <br><br>

        <!-- Tabs -->
        <v-card>
            <v-tabs grow v-model="tab" color="indigo">
                <v-tab v-for="tab in tabs" :key="tab">
                    <span>
                        <v-icon>{{ tab.icon }}</v-icon> {{tab.name}}
                    </span>
                </v-tab>
            </v-tabs>

            <v-tabs-items v-model="tab">
                <!-- Start Service Tab -->
                <v-tab-item>
                    <v-card class="mx-auto" flat>
                        <v-container fluid>
                            <v-row dense>
                                <v-col v-for="card in tilesFirstRow" :key="card.title" :cols="card.flex">
                                    <v-card>
                                        <v-icon>{{ card.icon }}</v-icon>
                                        <v-card-title v-text="card.title"></v-card-title>
                                        <v-card-text>{{ card.value }}</v-card-text>
                                    </v-card>
                                </v-col>
                            </v-row>
                            <v-row>
                                <v-col v-for="card in tilesSecondRow" :key="card.title" :cols="card.flex">
                                    <v-card>
                                        <v-icon>{{ card.icon }}</v-icon>
                                        <v-card-title v-text="card.title"></v-card-title>
                                        <v-card-text>{{ card.value }}</v-card-text>
                                    </v-card>
                                </v-col>
                            </v-row>
                        </v-container>
                    </v-card>

                    <!-- Sub-caption -->
                    <h5>{{ this.subCaption }}</h5>
                    <!-- End of Sub-caption -->

                    <!-- Start Service Button -->
                    <div id="divStartService">
                        <v-btn medium color="primary" dark @click="startService">
                            Start Service
                        </v-btn>
                    </div>
                    <!-- End of Start Service Button -->

                </v-tab-item>
                <!-- End of Start Service Tab -->

                <!-- Service Book Tab -->
                <v-tab-item>
                    <v-card flat>
                        <v-card-title class="headline">
                            Service Book Title
                        </v-card-title>
                        <v-card-text>
                            <service-book />
                        </v-card-text>
                    </v-card>
                </v-tab-item>
                <!-- End of Service Book Tab -->

            </v-tabs-items>
        </v-card>
        <!-- End of Tabs -->
    </v-container>

</template>

<script>
    import ServiceBook from './ServiceBook.vue'

    export default {
        name: "Services",
        components: {
            'service-book': ServiceBook
        },
        data() {
            return {
                tab: null,
                isStartService: true,
                isServiceBook: false,
                active_tab: 0,
                tabs: [{
                        index: 0,
                        name: 'Start Service',
                        icon: 'mdi-checkbox-marked-circle'
                    },
                    {
                        index: 1,
                        name: 'Service Book',
                        icon: 'mdi-book-open-variant'
                    }
                ],
                jobTitle: 'Hospital A | Pharmacy 1',
                subCaption: 'Scheduled Service: Full Onsite Service',
                tilesFirstRow: [{
                        index: 0,
                        title: 'Facility Name:',
                        value: 'Pharmacy B',
                        icon: 'mdi-domain'
                    },
                    {
                        index: 1,
                        title: 'Service Time:',
                        value: '3:00PM - 4:00PM',
                        icon: 'mdi-clock'
                    },
                    {
                        index: 2,
                        title: 'Customer Code:',
                        value: '2706 W Flournoy St Suite 500 Chicago, Illinois(IL), 60612',
                        icon: 'mdi-pound-box'
                    }
                ],
                tilesSecondRow: [{
                        index: 0,
                        title: 'Address:',
                        value: '2706 W Flournoy St Suite 500 Chicago, Illinois(IL), 60612',
                        icon: 'mdi-map-marker'
                    },
                    {
                        index: 1,
                        title: 'Scheduling Contact:',
                        value: 'Chris Barnes',
                        icon: 'mdi-human-greeting'
                    },
                    {
                        index: 2,
                        title: 'Phone:',
                        value: '(773) 826-0000',
                        icon: 'mdi-phone'
                    }
                ]
            }
        },
        mounted() {

        },
        methods: {
            backToCalender() {
                console.log('Return to Calender called.')
            },
            startService() {
                console.log('Start Service clicked!')
            }
        },
    }
</script>

<style>
    .btnReturn {
        display: flex;
        align-content: center;
        justify-content: center;
        border-radius: 50%;
        border-width: 2px;
        border: 2px;
        position: static;
        left: 12.5%;
        right: 12.5%;
        top: 12.5%;
        bottom: 12.5%;

        /* color/accent */
        border: 2px solid #0063A7;
    }

    .divStartSvc {
        display: flex;
        flex-direction: column;
        align-items: flex-start;
        padding: 20px;

        position: static;
        width: 1736px;
        height: 700px;
        left: 0px;
        top: 94px;

        /* color/accent/background */
        background: #F7F9FE;
        border-radius: 8px;

        /* Inside Auto Layout */
        flex: none;
        order: 1;
        align-self: stretch;
        flex-grow: 0;
        margin: 40px 0px;
    }

    #divStartService {
        display: flex;
        align-items: center;
        justify-content: center;
    }

    h5 {
        /* desktop/h5 */
        font-family: Arial;
        font-style: normal;
        font-weight: bold;
        font-size: 15px;
        line-height: 150%;
        /* identical to box height, or 42px */
        display: flex;
        align-items: center;
        justify-content: center;
        letter-spacing: 0.5px;

        /* text/body */
        color: #383839;
    }
</style>