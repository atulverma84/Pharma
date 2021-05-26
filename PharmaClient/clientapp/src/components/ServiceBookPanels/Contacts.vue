<template>
    <div id="contacts">
        <v-row>
            <v-dialog v-model="dialog" persistent max-width="600px">
                <template v-slot:activator="{ on, attrs }">
                    <div id="editButton">
                        <v-btn color="primary" dark tile v-bind="attrs" v-on="on">
                            <v-icon left>
                                mdi-square-edit-outline
                            </v-icon>
                            Edit Information
                        </v-btn>
                    </div>
                </template>
                <v-card>
                    <v-card-title>
                        <span class="headline">Contacts</span>
                    </v-card-title>
                    <v-card-text>
                        <v-container>
                            <v-row>
                                <h5>Scheduling Contact:</h5>
                                <v-col cols="12" sm="6" md="4">
                                    <v-text-field label="First name*" required></v-text-field>
                                </v-col>
                                <v-col cols="12" sm="6" md="4">
                                    <v-text-field label="Last name*" hint="example of persistent helper text"
                                        persistent-hint required></v-text-field>
                                </v-col>
                                <v-col cols="12">
                                    <v-text-field label="Phone*" required></v-text-field>
                                </v-col>
                                <v-col cols="12">
                                    <v-text-field label="Email*" required></v-text-field>
                                </v-col>                                
                            </v-row>
                            <v-spacer></v-spacer>

                            <v-row>
                                <h5>Service Contacts:</h5>
                                <v-col cols="12" sm="6" md="4">
                                    <v-text-field label="First name*" required></v-text-field>
                                </v-col>
                                <v-col cols="12" sm="6" md="4">
                                    <v-text-field label="Last name*" hint="example of persistent helper text"
                                        persistent-hint required></v-text-field>
                                </v-col>
                                <v-col cols="12">
                                    <v-text-field label="Phone*" required></v-text-field>
                                </v-col>
                                <v-col cols="12">
                                    <v-text-field label="Email*" required></v-text-field>
                                </v-col>                                
                            </v-row>
                        </v-container>
                        <small>*indicates required field</small>
                    </v-card-text>
                    <v-card-actions>
                        <v-spacer></v-spacer>
                        <v-btn color="blue darken-1" text @click="dialog = false">
                            Close
                        </v-btn>
                        <v-btn color="blue darken-1" text @click="dialog = false">
                            Save
                        </v-btn>
                    </v-card-actions>
                </v-card>
            </v-dialog>
        </v-row>
    </div>
</template>

<script>
    export default {
        name: 'Contacts',
        data() {
            return {
                dialog: false
            }
        }
    }
</script>

<style>
#editButton {
    display: flex;
    align-items: flex-end;
    justify-content: flex-end;
}
</style>