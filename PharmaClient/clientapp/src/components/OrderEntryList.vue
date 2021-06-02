<template>
<div>
    <v-card>
            <v-card-title>
              Order Entry List
              <v-spacer></v-spacer>
              <v-text-field
                v-model="search"
                append-icon="mdi-magnify"
                label="Filter"
                single-line
                hide-details
              >
              </v-text-field>
            </v-card-title>
            <v-data-table
              :headers="headersData"
              :items="items"
              :search="search"
              item-key="policy_type"
              :loading="loadingvariable"
              loading-text="Loading... Please wait"
              show-expand
              class="elevation-1"
            >
              <template v-slot:expanded-item="{ item }">
                <td :colspan="items.length">
                  More info about {{ item.policy_name }}
                </td>
              </template>
              <template v-slot:[`item.policy_date`]="{ item }">
                <span>{{ dateTime(item.policy_date) }}</span>
              </template>
            </v-data-table>
          </v-card>
          <on-site-app>
          </on-site-app>
</div>
</template>

<script>
import OnSiteApp from './OnSiteApp.vue'

export default {
  components: { OnSiteApp },
 
 data: () => ({
    menu2: false,
    drugdate: new Date().toISOString().substr(0, 10),
    loadingvariable: true,
    drugName: "",
    result: "",
    valid: true,
    error: null,
    search: "",
    items: [],
    nameRules: [(v) => !!v || "Required"],
    alert: false,
    headersData: [
        { text: "", value: "v-radio" },
      { text: "Entry", value: "policy_name" },
      { text: "Product Name", value: "policy_date" },
      { text: "Strength", value: "policy_type" },
      { text: "Lot#", value: "data-table-expand" },
      { text: "Qty Full", value: "policy_name" },
      { text: "Qty Part", value: "policy_date" },
      { text: "Amount", value: "policy_type" },
      { text: "Manufacturer", value: "data-table-expand" },
      { text: "Controlled", value: "data-table-expand" },
      { text: "More", value: "data-table-expand" },
      { text: "Edit", value: "data-table-expand" },
    ],
  })
}
</script>

<style scoped>

</style>
