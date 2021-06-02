<template>
  <!-- Edit Information Button-->
      <v-row justify="end" class="pr-5" no-gutters>
        <v-col md="1" class="text-right">
          <div id="editButton">
            <span>
              <v-btn color="primary" dark @click="EditInfo" icon>
                <v-icon left>
                  mdi-square-edit-outline
                </v-icon>
                Edit Information
              </v-btn>
            </span>
          </div>
        </v-col>
      </v-row>
      <!-- End of Edit Information Button-->
</template>

<script>
export default {
    name: 'EditInformation',
    data() {
      return {
        isClicked: true
      }
    },
    methods: {
      EditInfo() {
        this.$emit('clicked', this.isClicked)
      }
    }
}
</script>

<style>

</style>