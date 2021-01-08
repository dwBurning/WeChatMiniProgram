const app = getApp();
// pages/mine/orders/orders.js
Page({

  /**
   * 页面的初始数据
   */
  data: {
    orders: [],
    hasList: false
  },

  /**
   * 生命周期函数--监听页面加载
   */
  onLoad: function(options) {

  },

  /**
   * 生命周期函数--监听页面初次渲染完成
   */
  onReady: function() {

  },

  /**
   * 生命周期函数--监听页面显示
   */
  onShow: function() {
    const self = this;
    wx.request({
      // + '?sessionKey=' + self.data.sessionKey
      url: app.globalData.urlOrders,
      success: function(res) {
        if (res.data.Context && res.data.Context.length > 0) {
          self.setData({
            hasList: true, // 既然有数据了，那设为true吧
            orders: res.data.Context
          });
        }
      },
      complete: function(res) {
        //self.getTotalPrice()
      }
    });
  },

  /**
   * 生命周期函数--监听页面隐藏
   */
  onHide: function() {

  },

  /**
   * 生命周期函数--监听页面卸载
   */
  onUnload: function() {

  },

  /**
   * 页面相关事件处理函数--监听用户下拉动作
   */
  onPullDownRefresh: function() {

  },

  /**
   * 页面上拉触底事件的处理函数
   */
  onReachBottom: function() {

  },

  /**
   * 用户点击右上角分享
   */
  onShareAppMessage: function() {

  }
})