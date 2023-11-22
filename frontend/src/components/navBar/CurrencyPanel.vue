<template>
    <div :style="{ backgroundColor: style.monthNavigatorPanel.background }" class="currency-dropdown">
        <div v-if="currencies === null" class="loading-container">
            <Loading />
        </div>
        <div v-else>
            <div class="currency-card" v-for:="(currency, idx) in currencies" :key="idx">
                <span>{{ currency.currencyCode }}</span>
                <span class="currency-card-rate-label">{{ currency.rate }}</span>
            </div>
        </div>
    </div>
</template>

<script setup lang="ts">
import { useStyleStore } from '../../stores/style';
import { onMounted, ref } from 'vue';
import { ApiService } from '../../api/ApiService';
import { Currency } from '../../models/data/Currency';
import Loading from "../other/Loading.vue";

const style = useStyleStore().sectionStyles.navBar

const currencies = ref<Currency[] | null>(null)
onMounted(() => {
    ApiService.getCurrencies()
        .then(res => currencies.value = res)
        .catch(error => console.error(error))
})
</script>

<style scoped>
.currency-dropdown {
    font-size: small;
    border-radius: 4px;
    margin-top: 4px;
    padding: 4px;
    min-width: 120px;
    height: 200px;
    overflow-y: scroll;
}

.loading-container {
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
}

.currency-card {
    display: flex;
    justify-content: space-between;
    padding: 4px;
}

.currency-card-rate-label {
    font-weight: bolder;
}
</style>