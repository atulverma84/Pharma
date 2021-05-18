<template>
    <div>
        <span id="returnToCalender">
            <v-btn elevation="2"
                   fab
                   small>
                <v-icon dark left>
                    mdi-arrow-left-bold-circle-outline
                </v-icon>
            </v-btn>
            <h4>{{ this.jobTitle }}</h4>
        </span>
        <br /><br />

        <v-card>
            <v-tabs grow v-model="active_tab"
                    background-color="indigo"
                    dark
                    icons-and-text>
                <v-tab v-for="tab of tabs"
                       :key="tab.index">
                    <span>
                        <v-icon>{{ tab.icon }}</v-icon> {{tab.name}}
                    </span>
                </v-tab>
            </v-tabs>

            <v-tabs-items v-model="tab">
                <!-- Start Service - Tab Item -->
                <v-tab-item>
                    <v-card flat>
                        <v-card elevation="2">
                            <v-card-title>
                                <h2>v-card-title</h2>
                            </v-card-title>

                            <v-card-text>
                                Start Service Content
                            </v-card-text>

                            <v-card-actions>
                                <v-btn flat color=primary>Start Service</v-btn>
                            </v-card-actions>

                        </v-card>
                    </v-card>
                </v-tab-item>
                <!-- End of Start Service - Tab Item -->
                <!-- Service Book - Tab Item -->
                <v-tab-item>
                    <v-card flat>
                        <v-card-text>{{ text }}</v-card-text>
                        <v-card elevation="2">
                            <v-card-title>
                                <h2>v-card-title</h2>
                            </v-card-title>

                            <v-card-text>
                                Service Book Content
                            </v-card-text>

                            <v-card-actions>
                                <v-btn flat color=primary>Service Book</v-btn>
                            </v-card-actions>

                        </v-card>
                    </v-card>
                </v-tab-item>
                <!-- End of Service Book - Tab Item -->
            </v-tabs-items>
        </v-card>
    </div>
</template>

<script>
    export default {
        name: "StartService",
        data() {
            return {
                tab: null,
                text: 'Lorem ipsum dolor sit amet.',
                active_tab: 0,
                tabs: [
                    { index: 0, name: 'Start Service', icon: 'mdi-checkbox-marked-circle', content: 'Start Service Content' },
                    { index: 1, name: 'Service Book', icon: 'mdi-book-open-variant', content: 'Service Book Content' }
                ],
                jobTitle: 'Hospital A | Pharmacy 1'
            }
        },
        mounted() {

        },
        methods: {

        },
    }
</script>

<style>
    .btnReturn {
        border-radius: 50%;
        border: 2px;
        color: lightgrey;
        position: static;
        left: 0%;
        right: 90.97%;
        top: 0%;
        bottom: 8.7%;
        flex: none;
        order: 0;
        flex-grow: 0;
        margin: 0px 24px;
    }
</style>